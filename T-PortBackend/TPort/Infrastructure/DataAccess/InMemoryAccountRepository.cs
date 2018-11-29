using System;
using System.Collections.Generic;
using TPort.Domain.Infrastructure.DataAccess;
using TPort.Domain.UserManagement;

namespace TPort.Infrastructure.DataAccess
{
    public class InMemoryAccountRepository : IAccountRepository
    {
        public bool TryToSaveAccount(Account account)
        {
            return _accounts.TryAdd(account.Id, account);
        }

        public Account LoadAccount(Guid id)
        {
            return _accounts.GetValueOrDefault(id);
        }

        private readonly Dictionary<Guid, Account> _accounts;
    }
}