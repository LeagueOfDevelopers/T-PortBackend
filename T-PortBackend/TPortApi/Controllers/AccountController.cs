using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TPort.Commons;
using TPort.Services;
using TPortApi.Models.AccountModels;
using TPortApi.Security;

namespace TPortApi.Controllers
{
    public class AccountController : Controller
    {
        public AccountController(IAccountManager accountManager, IJwtIssuer jwtIssuer, ISmsManager smsManager, ITotpManager totpManager)
        {
            _accountManager = accountManager ?? throw new ArgumentNullException(nameof(accountManager));
            _jwtIssuer = jwtIssuer ?? throw new ArgumentNullException(nameof(jwtIssuer));
            _smsManager = smsManager;
            _totpManager = totpManager;
        }

        /// <summary>
        ///     Sends a verification code to the entered phone number.
        /// </summary>
        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody] LoginRequest loginRequest)
        {
            _smsManager.SendMessage(loginRequest.Phone, 
                _totpManager.GenerateToken(loginRequest.Phone)
                    .ToString());
            
            return Ok();
        }

        /// <summary>
        ///     Checks verification code.
        /// </summary>
        /// <returns>
        /// Jwt token.
        /// </returns>
        [HttpPut]
        [Route("login")]
        public IActionResult Login([FromBody] LoginConfirmationRequest loginConfirmationRequest)
        {
            _totpManager.ValidateToken(loginConfirmationRequest.Phone, loginConfirmationRequest.Code);
            var account = _accountManager.LoadAccount(loginConfirmationRequest.Phone);
            var credentials = new Credentials(Request.Headers["User-Agent"], loginConfirmationRequest.Phone);
            var accountId = account?.Id ?? _accountManager.CreateAccount(credentials);
            var token = _jwtIssuer.IssueJwt(accountId);
            return Ok(new LoginResponse(token));
        }
        
        [HttpPost]
        [Route("account/cards")]
        [Authorize]
        public ActionResult AddBankCard([FromBody]BankCardModel bankCardModel)
        {
            var accountId = Request.GetUserId();
            _accountManager.AddBankCardToAccount(bankCardModel.CardNumber, bankCardModel.Validity, accountId);
            return Ok();
        }

        private readonly ISmsManager _smsManager;
        private readonly IAccountManager _accountManager;
        private readonly IJwtIssuer _jwtIssuer;
        private readonly ITotpManager _totpManager;
    }
}