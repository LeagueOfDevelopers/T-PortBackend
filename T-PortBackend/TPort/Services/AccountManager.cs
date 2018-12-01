using System;
using System.Net.Mail;
using TPort.Domain.Exceptions;
using TPort.Domain.Infrastructure.DataAccess;
using TPort.Domain.UserManagement;

namespace TPort.Services
{
    public class AccountManager
    {
        public Guid CreateAccount(string firstName, string lastName, MailAddress email,
            string password)
        {
            var newAccount = new Account(
                Guid.NewGuid(), 
                firstName, 
                lastName, 
                new Credentials(email, password), 
                DateTimeOffset.Now);
            
            var accountSaved = _accountRepository.TryToSaveAccount(newAccount);
            
            if(!accountSaved)
                throw new AccountAlreadyExistsException();
            
            return newAccount.Id;
        }

        private readonly IAccountRepository _accountRepository;
    }
}