using System;
using System.Collections.Generic;

namespace TPort.Domain.RouteManagement
{
    public class Trip
    {
        public Trip(Guid id, City departureCity, City destinationCity, List<Route> routes, double cost, TimeSpan duration)
        {
            Id = id;
            DepartureCity = departureCity ?? throw new ArgumentNullException(nameof(departureCity));
            DestinationCity = destinationCity ?? throw new ArgumentNullException(nameof(destinationCity));
            _routes = routes ?? throw new ArgumentNullException(nameof(routes));
            Cost = cost;
            Duration = duration;
        }

        public Guid Id { get; }
        
        public City DepartureCity { get; }
        
        public City DestinationCity { get; }
        
        public IEnumerable<Route> Routes => _routes;
        
        public double Cost { get; }
        
        public TimeSpan Duration { get; }
        
        private readonly List<Route> _routes;
    }
}