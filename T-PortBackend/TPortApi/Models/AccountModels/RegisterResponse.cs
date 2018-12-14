using System;

namespace TPortApi.Models.AccountModels
{
    public class RegisterResponse
    {
        public RegisterResponse(Guid accountId)
        {
            AccountId = accountId;
        }

        public Guid AccountId { get; }
    }
}