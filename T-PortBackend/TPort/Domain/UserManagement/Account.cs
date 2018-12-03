using System;
using System.Collections.Generic;

namespace TPort.Domain.UserManagement
{
    public class Account
    {
        public Account(
            Guid id,
            string firstName,
            string surname, 
            Credentials userCredentials,
            DateTimeOffset registrationTime,
            List<BankCardData> connectedUsersBankCardData,
            List<PassportData> connectedUsersPassportsData)
        {
            Id = id;
            FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
            Surname = surname ?? throw new ArgumentNullException(nameof(surname));
            UserCredentials = userCredentials ?? throw new ArgumentNullException(nameof(userCredentials));
            RegistrationTime = registrationTime;
            _connectedUsersBankCardData = connectedUsersBankCardData ??
                                          throw new ArgumentNullException(nameof(connectedUsersBankCardData));
            _connectedUsersPassportsData = connectedUsersPassportsData ??
                                           throw new ArgumentNullException(nameof(connectedUsersPassportsData));
        }

        public Guid Id { get; }
        
        public string FirstName { get; }
        
        public string Surname { get; }
        
        public Credentials UserCredentials { get; }
        
        public DateTimeOffset RegistrationTime { get; }

        public IEnumerable<PassportData> ConnectedUsersPassportsData => _connectedUsersPassportsData;

        public IEnumerable<BankCardData> ConnectedUsersBankCardData => _connectedUsersBankCardData;

        private readonly List<BankCardData> _connectedUsersBankCardData;
        private readonly List<PassportData> _connectedUsersPassportsData;

    }
}