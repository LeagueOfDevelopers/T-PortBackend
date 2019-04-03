using System;
using TPort.Common;
using TPort.Domain.UserManagement;

namespace TPort.Services
{
    public interface IAccountManager
    {
        Guid CreateAccount(Credentials credentials);

        Account LoadAccount(string phoneNumber);

        void AddTripToAccount(Guid tripId, Guid accountId);

        void AddBankCardToAccount(string cardNumber, DateTime validity, Guid accountId);
    }
}