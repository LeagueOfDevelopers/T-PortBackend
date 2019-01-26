using System;
using System.Collections.Generic;
using System.Linq;
using TPort.Domain.RouteManagement;

namespace TPort.Infrastructure.DataAccess
{
    public class InMemoryTripRepository : ITripRepository
    {
        public InMemoryTripRepository(List<Trip> trips)
        {
            _trips = trips ?? throw new ArgumentNullException(nameof(trips));
        }

        public IEnumerable<Trip> Trips => _trips;
            
        public void SaveTrip(Trip trip)
        {
            if (_trips.Contains(trip))
                _trips.Remove(trip);
            
            _trips.Add(trip);
        }

        public Trip LoadTrip(Guid tripId)
        {
            return _trips.FirstOrDefault(trip => trip.Id == tripId);
        }

        private readonly List<Trip> _trips;
    }
}