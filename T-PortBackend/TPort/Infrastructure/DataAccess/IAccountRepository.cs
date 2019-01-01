using System;
using TPort.Common;
using TPort.Domain.UserManagement;

namespace TPort.Infrastructure.DataAccess
{
    public interface IAccountRepository
    {
        void SaveAccount(Account account);
        
        Account LoadAccountById(Guid id);

        Account LoadAccountByPhoneNumber(string phoneNumber);
        
        Account GetUserByCredentials(Credentials credentials);
    }
}