using System;
using System.Collections.Generic;
using System.Net.Mail;
using TPort.Common;
using TPort.Domain.Exceptions;
using TPort.Domain.UserManagement;
using TPort.Infrastructure.DataAccess;

namespace TPort.Services
{
    public class AccountManager
    {
        public AccountManager(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));
        }

        public Guid CreateAccount(string firstName, string lastName, Credentials credentials)
        {
            var newAccount = new Account(
                Guid.NewGuid(), 
                firstName, 
                lastName, 
                credentials, 
                DateTimeOffset.Now,
                new List<BankCardData>(),
                new List<PassportData>());
            
            var accountSaved = _accountRepository.TryToSaveAccount(newAccount);
            
            if(!accountSaved)
                throw new AccountAlreadyExistsException();
            
            return newAccount.Id;
        }
        
        public Account FindByCredentials(Credentials credentials)
        {
            return _accountRepository.GetUserByCredentials(credentials);
        }

        private readonly IAccountRepository _accountRepository;
    }
}