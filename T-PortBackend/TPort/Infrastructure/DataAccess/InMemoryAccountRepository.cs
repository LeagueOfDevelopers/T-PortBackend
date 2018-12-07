using System;
using System.Collections.Generic;
using System.Linq;
using TPort.Common;
using TPort.Domain.UserManagement;

namespace TPort.Infrastructure.DataAccess
{
    public class InMemoryAccountRepository : IAccountRepository
    {
        public InMemoryAccountRepository(Dictionary<Guid, Account> accounts)
        {
            _accounts = accounts ?? throw new ArgumentNullException(nameof(accounts));
        }

        public bool TryToSaveAccount(Account account)
        {
            return _accounts.TryAdd(account.Id, account);
        }

        public Account LoadAccount(Guid id)
        {
            return _accounts.GetValueOrDefault(id);
        }

        public Account GetUserByCredentials(Credentials credentials)
        {
            return _accounts.Values.FirstOrDefault(account => account.UserCredentials == credentials);
        }

        private readonly Dictionary<Guid, Account> _accounts;
    }
}