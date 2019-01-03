using System;
using Microsoft.AspNetCore.Mvc;
using TPort.Services;
using TPortApi.Models.RouteModels;

namespace TPortApi.Controllers
{
    public class RouteController : Controller
    {
        public RouteController(RouteManager routeManager)
        {
            _routeManager = routeManager ?? throw new ArgumentNullException(nameof(routeManager));
        }

        [HttpPost]
        [Route("search")]
        public ActionResult FindRoutes([FromBody] RequestRoute requestRoute)
        {
            return Ok(_routeManager
                .FindRoutes(requestRoute.DepartureCityCode, requestRoute.DestinationCityCode, requestRoute.DepartDate));
        }

        private readonly RouteManager _routeManager;
    }
}