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
        public AccountController(AccountManager accountManager, IJwtIssuer jwtIssuer)
        {
            _accountManager = accountManager ?? throw new ArgumentNullException(nameof(accountManager));
            _jwtIssuer = jwtIssuer ?? throw new ArgumentNullException(nameof(jwtIssuer));
        }

        [HttpPost]
        [Route("register")]
        public IActionResult RegisterUser([FromBody]RegisterUserRequest registerRequest)
        {
            var newUserId = _accountManager.CreateAccount(
                registerRequest.FirstName,
                registerRequest.LastName, 
                Credentials.FromRawData(
                    new MailAddress(registerRequest.Email),
                    registerRequest.Password));
            var response = new RegisterResponse(newUserId);
            return Ok(response);
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody] LoginRequest loginRequest)
        {
            var credentials = Credentials.FromRawData(new MailAddress(loginRequest.Email), loginRequest.Password);
            var account = _accountManager.FindByCredentials(credentials);

            if (account == null) return Unauthorized();
            var token = _jwtIssuer.IssueJwt(account.Id);
            return Ok(new LoginResponse(token));

        }

        private readonly AccountManager _accountManager;
        private readonly IJwtIssuer _jwtIssuer;
    }
}