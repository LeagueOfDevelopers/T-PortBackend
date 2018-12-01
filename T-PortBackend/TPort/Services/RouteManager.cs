using System;
using System.Collections.Generic;
using TPort.Domain.Infrastructure.DataAccess;
using TPort.Domain.RouteManagement;
using TPort.Infrastructure.DataAccess;

namespace TPort.Services
{
    public class RouteManager
    {
        public RouteManager(IAccountRepository accountRepository, IRouteRepository routeRepository)
        {
            _accountRepository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));
            _routeRepository = routeRepository ?? throw new ArgumentNullException(nameof(routeRepository));
        }

        public Route BuildRoute(Address departureAddress, Address arrivalAddress, Guid userId) //Заглушка пока
        {
            var builtRoute = new Route(
                Guid.NewGuid(),
                departureAddress,
                arrivalAddress,
                new List<RouteSegment>()
            );
            // Будет еще добавление в историю маршрутов юзера
            _routeRepository.SaveRoute(builtRoute);
            
            return builtRoute;

        }

        private readonly IAccountRepository _accountRepository;
        private readonly IRouteRepository _routeRepository;
    }
}