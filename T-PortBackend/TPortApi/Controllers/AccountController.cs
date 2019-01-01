using System;
using System.Net.Mail;
using Microsoft.AspNetCore.Mvc;
using TPort.Common;
using TPort.Services;
using TPortApi.Models.AccountModels;
using TPortApi.Security;

namespace TPortApi.Controllers
{
    public class AccountController : Controller
    {
        public AccountController(AccountManager accountManager, IJwtIssuer jwtIssuer, SmsManager smsManager, TotpManager totpManager)
        {
            _accountManager = accountManager ?? throw new ArgumentNullException(nameof(accountManager));
            _jwtIssuer = jwtIssuer ?? throw new ArgumentNullException(nameof(jwtIssuer));
            _smsManager = smsManager;
            _totpManager = totpManager;
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody] LoginRequest loginRequest)
        {
            _smsManager.SendMessage(loginRequest.Phone, 
                _totpManager.GenerateToken(loginRequest.Phone)
                    .ToString());
            
            return Ok();

        }

        [HttpPut]
        [Route("login")]
        public IActionResult Login([FromBody] LoginConfirmationRequest loginConfirmationRequest)
        {
            _totpManager.ValidateToken(loginConfirmationRequest.Phone, loginConfirmationRequest.Code);
            var account = _accountManager.LoadAccount(loginConfirmationRequest.Phone);
            var credentials = Credentials.FromRawData(loginConfirmationRequest.Phone, Request.Headers["User-Agent"]);
            var accountId = account?.Id ?? _accountManager.CreateAccount(credentials);
            var token = _jwtIssuer.IssueJwt(accountId);
            return Ok(new LoginResponse(token));
        }

        private readonly SmsManager _smsManager;
        private readonly AccountManager _accountManager;
        private readonly IJwtIssuer _jwtIssuer;
        private readonly TotpManager _totpManager;
    }
}