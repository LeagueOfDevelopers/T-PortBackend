using System;
using TPort.Domain.RouteManagement;

namespace TPort.Infrastructure.DataAccess
{
    public interface IRouteRepository
    {
        void SaveRoute(Route route);

        Route LoadRoute(Guid routeId);
    }
}