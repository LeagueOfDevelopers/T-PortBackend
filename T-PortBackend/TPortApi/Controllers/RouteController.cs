using System;
using Microsoft.AspNetCore.Mvc;
using TPort.Services;
using TPortApi.Models.RouteModels;

namespace TPortApi.Controllers
{
    public class RouteController : Controller
    {
        public RouteController(RouteManager routeManager, CityManager cityManager)
        {
            _routeManager = routeManager ?? throw new ArgumentNullException(nameof(routeManager));
            _cityManager = cityManager ?? throw new ArgumentNullException(nameof(cityManager));
        }

        [HttpPost]
        [Route("search")]
        public ActionResult FindRoutes([FromBody] RequestRoute requestRoute)
        {
            var departureCity = _cityManager.FindCity(requestRoute.DepartureCity);
            var destinationCity = _cityManager.FindCity(requestRoute.DestinationCity);
            return Ok(_routeManager
                .FindRoutes(departureCity, destinationCity, requestRoute.DepartDate));
        }

        private readonly CityManager _cityManager;
        private readonly RouteManager _routeManager;
    }
}