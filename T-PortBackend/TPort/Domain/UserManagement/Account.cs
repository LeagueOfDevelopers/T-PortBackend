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
            List<BankCardData> connectedUsersBankCardData,
            List<PassportData> connectedUsersPassportsData)
        {
            Id = id;
            UserCredentials = userCredentials ?? throw new ArgumentNullException(nameof(userCredentials));
            RegistrationTime = registrationTime;
            _plannedTripsIds = plannedTripsIds ?? throw new ArgumentNullException(nameof(plannedTripsIds));
            _connectedUsersBankCardData = connectedUsersBankCardData ??
                                          throw new ArgumentNullException(nameof(connectedUsersBankCardData));
            _connectedUsersPassportsData = connectedUsersPassportsData ??
                                           throw new ArgumentNullException(nameof(connectedUsersPassportsData));
        }

        public Guid Id { get; }
        
        public Credentials UserCredentials { get; }
        
        public DateTimeOffset RegistrationTime { get; }

        public IEnumerable<Guid> PlannedTrips => _plannedTripsIds;

        public IEnumerable<PassportData> ConnectedUsersPassportsData => _connectedUsersPassportsData;

        public IEnumerable<BankCardData> ConnectedUsersBankCardData => _connectedUsersBankCardData;

        public void AddPlannedTrip(Guid tripId)
        {
            _plannedTripsIds.Add(tripId);
        }

        private readonly List<Guid> _plannedTripsIds;
        private readonly List<BankCardData> _connectedUsersBankCardData;
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