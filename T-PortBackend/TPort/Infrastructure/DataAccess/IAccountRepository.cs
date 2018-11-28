using System;
using TPort.Domain.UserManagement;

namespace TPort.Domain.Infrastructure.DataAccess
{
    public interface IAccountRepository
    {
        bool TryToSaveAccount(Account account);

        Account LoadAccount(Guid id);
    }
}