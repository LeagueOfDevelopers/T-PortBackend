using System;
using TPort.Common;
using TPort.Domain.UserManagement;

namespace TPort.Infrastructure.DataAccess
{
    public interface IAccountRepository
    {
        bool TryToSaveAccount(Account account);

        Account LoadAccount(Guid id);
        Account GetUserByCredentials(Credentials credentials);
    }
}