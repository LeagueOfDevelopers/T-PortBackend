using System;
using System.Collections.Generic;
using TPort.Common;
using TPort.Domain.RouteManagement;
using TPort.Domain.UserManagement;
using TPort.Infrastructure.DataAccess;

namespace TPort.Services
{
    public class AccountManager
    {
        public AccountManager(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));
        }

        public Guid CreateAccount(Credentials credentials)
        {
            var newAccount = new Account(
                Guid.NewGuid(), 
                credentials, 
                DateTimeOffset.Now,
                new List<Guid>(), 
                new List<BankCardData>(),
                new List<PassportData>());
            
            _accountRepository.SaveAccount(newAccount);

            return newAccount.Id;
        }

        public Account LoadAccount(string phoneNumber) //TODO тут не должно быть этого, нужно убрать логику из контроллера если можно и перенести ее сюда
        {
            return _accountRepository.LoadAccountByPhoneNumber(phoneNumber);
        }

        public void AddTripToAccount(Guid tripId, Guid accountId)
        {
            var account = _accountRepository.LoadAccountById(accountId);
            account.AddPlannedTrip(tripId);
            _accountRepository.SaveAccount(account);
        }

        private readonly IAccountRepository _accountRepository;
    }
}