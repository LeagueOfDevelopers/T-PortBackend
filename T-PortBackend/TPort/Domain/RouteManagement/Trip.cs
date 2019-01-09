using System;
using System.Collections.Generic;

namespace TPort.Domain.RouteManagement
{
    public class Trip
    {
        public Trip(Guid id, Destination destination, List<Route> routes, double cost)
        {
            Id = id;
            Destination = destination ?? throw new ArgumentNullException(nameof(destination));
            _routes = routes ?? throw new ArgumentNullException(nameof(routes));
            Cost = cost;
        }

        public Guid Id { get; }
        
        public Destination Destination { get; }
        
        public IEnumerable<Route> Routes => _routes;
        
        public double Cost { get; }
        
        private readonly List<Route> _routes;
    }
}