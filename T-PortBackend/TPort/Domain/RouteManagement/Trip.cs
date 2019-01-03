using System;

namespace TPort.Domain.RouteManagement
{
    public class Trip
    {
        public Trip(int id, City departureCity, City destinationCity, int cost, DateTimeOffset timeTravel)
        {
            Id = id;
            DepartureCity = departureCity ?? throw new ArgumentNullException(nameof(departureCity));
            DestinationCity = destinationCity ?? throw new ArgumentNullException(nameof(destinationCity));
            Cost = cost;
            TimeTravel = timeTravel;
        }

        public int Id { get; }
        
        public City DepartureCity { get; }
        
        public City DestinationCity { get; }
        
        public int Cost { get; }
        
        public DateTimeOffset TimeTravel { get; }
    }
}