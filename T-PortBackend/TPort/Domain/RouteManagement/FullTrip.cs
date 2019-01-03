using System;
using System.Collections.Generic;

namespace TPort.Domain.RouteManagement
{
    public class FullTrip
    {
        public FullTrip(List<Route> routes, int id, Trip trip)
        {
            _routes = routes ?? throw new ArgumentNullException(nameof(routes));
            Id = id;
            Trip = trip ?? throw new ArgumentNullException(nameof(trip));
        }

        public int Id { get; }
        
        public Trip Trip { get; }

        public IEnumerable<Route> Routes => _routes;

        private readonly List<Route> _routes;
    }
}