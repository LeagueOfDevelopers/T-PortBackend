using System;
using TPort.Common;
using TPort.Domain.UserManagement;

namespace TPort.Infrastructure.DataAccess
{
    public interface IAccountRepository
    {
        void SaveAccount(Account account);
        
        Account LoadAccount(Guid id);

        Account LoadAccount(string phoneNumber);
        
        Account LoadAccount(Credentials credentials);
    }
}