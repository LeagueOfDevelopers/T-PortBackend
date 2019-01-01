using System;
using System.Collections.Generic;
using TPort.Common;
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

        public Guid CreateAccount(Credentials credentials)
        {
            var newAccount = new Account(
                Guid.NewGuid(), 
                credentials, 
                DateTimeOffset.Now,
                new List<BankCardData>(),
                new List<PassportData>());
            
            _accountRepository.SaveAccount(newAccount);

            return newAccount.Id;
        }

        public Account LoadAccount(string phoneNumber)
        {
            return _accountRepository.LoadAccountByPhoneNumber(phoneNumber);
        }

        private readonly IAccountRepository _accountRepository;
    }
}