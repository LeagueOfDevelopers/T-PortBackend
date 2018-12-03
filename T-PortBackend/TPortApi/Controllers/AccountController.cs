using System;
using System.Net.Mail;
using Microsoft.AspNetCore.Mvc;
using TPort.Services;
using TPortApi.Models;

namespace TPortApi.Controllers
{
    public class AccountController : Controller
    {
        public AccountController(AccountManager accountManager)
        {
            _accountManager = accountManager ?? throw new ArgumentNullException(nameof(accountManager));
        }

        [HttpPost]
        [Route("register")]
        public IActionResult RegisterUser(RegisterUserRequest registerRequest)
        {
            var newUserId = _accountManager.CreateAccount(
                registerRequest.FirstName,
                registerRequest.LastName, 
                new MailAddress(registerRequest.Email),
                registerRequest.Password);
            return Ok(newUserId);
        }

        private readonly AccountManager _accountManager;
    }
}