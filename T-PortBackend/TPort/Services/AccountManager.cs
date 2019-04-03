using System;
using System.Collections.Generic;
using TPort.Commons;
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
                new List<BankCard>(),
                new List<PassportData>());
            
            _accountRepository.SaveAccount(newAccount);

            return newAccount.Id;
        }

        public Account LoadAccount(string phoneNumber) //TODO тут не должно быть этого, нужно убрать логику из контроллера если можно и перенести ее сюда
        {
            return _accountRepository.LoadAccount(phoneNumber);
        }

        public void AddTripToAccount(Guid tripId, Guid accountId)
        {
            var account = _accountRepository.LoadAccount(accountId);
            account.AddPlannedTrip(tripId);
            _accountRepository.SaveAccount(account);
        }

        public void AddBankCardToAccount(string cardNumber, DateTime validity, Guid accountId)
        {
            var account = _accountRepository.LoadAccount(accountId);
            account.AddBankCard(new BankCard(cardNumber, validity));
            _accountRepository.SaveAccount(account);
        }

        private readonly IAccountRepository _accountRepository;
    }
}