using System;
using System.Collections.Generic;
using TPort.Common;

namespace TPort.Domain.UserManagement
{
    public class Account
    {
        public Account(
            Guid id,
            Credentials userCredentials,
            DateTimeOffset registrationTime,
            List<Guid> plannedTripsIds,
            List<BankCard> connectedUsersBankCardData,
            List<PassportData> connectedUsersPassportsData)
        {
            Id = id;
            UserCredentials = userCredentials ?? throw new ArgumentNullException(nameof(userCredentials));
            RegistrationTime = registrationTime;
            _plannedTripsIds = plannedTripsIds ?? throw new ArgumentNullException(nameof(plannedTripsIds));
            _bankCards = connectedUsersBankCardData ??
                                          throw new ArgumentNullException(nameof(connectedUsersBankCardData));
            _connectedUsersPassportsData = connectedUsersPassportsData ??
                                           throw new ArgumentNullException(nameof(connectedUsersPassportsData));
        }

        public Guid Id { get; }
        
        public Credentials UserCredentials { get; }
        
        public DateTimeOffset RegistrationTime { get; }

        public IEnumerable<Guid> PlannedTrips => _plannedTripsIds;

        public IEnumerable<PassportData> ConnectedUsersPassportsData => _connectedUsersPassportsData;

        public IEnumerable<BankCard> BankCards => _bankCards;

        public void AddPlannedTrip(Guid tripId)
        {
            _plannedTripsIds.Add(tripId);
        }

        public void AddBankCard(BankCard bankCard)
        {
            _bankCards.Add(bankCard);
        }

        private readonly List<Guid> _plannedTripsIds;
        private readonly List<BankCard> _bankCards;
        private readonly List<PassportData> _connectedUsersPassportsData;
        
        protected bool Equals(Account other)
        {
            return Id.Equals(other.Id) && UserCredentials.Equals(other.UserCredentials);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Account) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Id.GetHashCode() * 397) ^ UserCredentials.GetHashCode();
            }
        }
    }
}