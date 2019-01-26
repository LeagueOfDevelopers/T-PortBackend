using System;
using System.Collections.Generic;
using System.Linq;
using TPort.Common;
using TPort.Domain.UserManagement;

namespace TPort.Infrastructure.DataAccess
{
    public class InMemoryAccountRepository : IAccountRepository
    {
        public InMemoryAccountRepository(List<Account> accounts)
        {
            _accounts = accounts ?? throw new ArgumentNullException(nameof(accounts));
        }

        public void SaveAccount(Account account)
        {
            if (_accounts.Contains(account))
                _accounts.Remove(account);
            _accounts.Add(account);
        }

        public Account LoadAccountById(Guid id)
        {
            return _accounts.FirstOrDefault(account => account.Id == id);
        }

        public Account LoadAccountByPhoneNumber(string phoneNumber) // TODO желательно сделать их перегрузками
        {
            return _accounts.FirstOrDefault(account => account.UserCredentials.PhoneNumber == phoneNumber);
        }

        public Account GetUserByCredentials(Credentials credentials)
        {
            return _accounts.FirstOrDefault(account => account.UserCredentials == credentials);
        }

        private readonly List<Account> _accounts;
    }
}