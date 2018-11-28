using System;
using System.Net.Mail;
using TPort.Domain.Exceptions;
using TPort.Domain.Infrastructure.DataAccess;
using TPort.Domain.UserManagement;

namespace TPort.Services
{
    public class AccountManager
    {
        public Guid CreateAccount(string firstName, string middleName, string lastName, MailAddress email,
            string password)
        {
            var newAccount = new Account(Guid.NewGuid(), firstName, middleName, lastName, email, password,
                DateTimeOffset.Now);
            var accountSaved = _accountRepository.TryToSaveAccount(newAccount);
            
            if(!accountSaved)
                throw new AccountAlreadyExistsException();
            
            return newAccount.Id;
        }

        private readonly IAccountRepository _accountRepository;
    }
}