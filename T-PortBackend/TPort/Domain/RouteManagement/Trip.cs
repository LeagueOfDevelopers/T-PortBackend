using System;
using System.Collections.Generic;

namespace TPort.Domain.RouteManagement
{
    public class Trip
    {
        public Trip(Guid id, string departureCityCode, string destinationCityCode, List<Route> routes, int cost, TimeSpan duration)
        {
            Id = id;
            DepartureCityCode = departureCityCode ?? throw new ArgumentNullException(nameof(departureCityCode));
            DestinationCityCode = destinationCityCode ?? throw new ArgumentNullException(nameof(destinationCityCode));
            _routes = routes ?? throw new ArgumentNullException(nameof(routes));
            Cost = cost;
            Duration = duration;
        }

        public Guid Id { get; }
        
        public string DepartureCityCode { get; }
        
        public string DestinationCityCode { get; }
        
        public IEnumerable<Route> Routes => _routes;

        private readonly List<Route> _routes;
        
        public int Cost { get; }
        
        public TimeSpan Duration { get; }
    }
}