using System;
using System.Collections.Generic;
using TPort.Domain.RouteManagement;
using TPort.Infrastructure.DataAccess;

namespace TPort.Services
{
    public class RouteManager
    {
        public RouteManager(IRouteRepository routeRepository)
        {
            _routeRepository = routeRepository ?? throw new ArgumentNullException(nameof(routeRepository));
        }

        public Route BuildRoute(Address departureAddress, Address arrivalAddress, Guid userId) //Заглушка пока
        {
            var builtRoute = new Route(
                Guid.NewGuid(), 
                Guid.NewGuid(),
                departureAddress,
                arrivalAddress,
                new List<RouteSegment>()
            );
            // Будет еще добавление в историю маршрутов юзера
            _routeRepository.SaveRoute(builtRoute);
            
            return builtRoute;

        }

        private readonly IRouteRepository _routeRepository;
    }
}