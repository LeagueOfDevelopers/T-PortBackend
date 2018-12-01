using System;
using System.Collections.Generic;
using TPort.Domain.RouteManagement;

namespace TPort.Infrastructure.DataAccess
{
    public class InMemoryRouteRepository : IRouteRepository
    {
        public InMemoryRouteRepository(Dictionary<Guid, Route> routes)
        {
            _routes = routes ?? throw new ArgumentNullException(nameof(routes));
        }

        public void SaveRoute(Route route)
        {
            _routes.Add(route.Id, route);
        }

        public Route LoadRoute(Guid routeId)
        {
            return _routes.GetValueOrDefault(routeId);
        }

        private readonly Dictionary<Guid, Route> _routes;
    }
}