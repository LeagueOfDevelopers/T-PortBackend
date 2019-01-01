using System;
using System.Collections.Generic;
using System.Linq;
using TPort.Common;
using TPort.Domain.UserManagement;

namespace TPort.Infrastructure.DataAccess
{
    public class InMemoryAccountRepository : IAccountRepository
    {
        public InMemoryAccountRepository(Dictionary<string, Account> accounts)
        {
            _accounts = accounts ?? throw new ArgumentNullException(nameof(accounts));
        }

        public void SaveAccount(Account account)
        {
            _accounts.Add(account.UserCredentials.PhoneNumber, account);
        }

        public Account LoadAccountById(Guid id)
        {
            return _accounts.Values.FirstOrDefault(account => account.Id == id);
        }

        public Account LoadAccountByPhoneNumber(string phoneNumber)
        {
            return _accounts.GetValueOrDefault(phoneNumber);
        }

        public Account GetUserByCredentials(Credentials credentials)
        {
            return _accounts.Values.FirstOrDefault(account => account.UserCredentials == credentials);
        }

        private readonly Dictionary<string, Account> _accounts;
    }
}