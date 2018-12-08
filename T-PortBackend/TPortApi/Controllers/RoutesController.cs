using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TPort.Domain.RouteManagement;
using TPort.Services;
using TPortApi.Models;
using TPortApi.Models.RouteModels;

namespace TPortApi.Controllers
{
    public class RoutesController : Controller
    {
        public RoutesController(RouteManager routeManager)
        {
            _routeManager = routeManager ?? throw new ArgumentNullException(nameof(routeManager));
        }

        [HttpPost]
        [Route("route")]
        public ActionResult BuildRoute([FromBody] RequestRoute requestRoute)
        {
            var builtRoute = _routeManager.BuildRoute(
                requestRoute.Origin,
                requestRoute.Destination,
                requestRoute.UserId
            );

            return Ok(builtRoute);
        }

        private readonly RouteManager _routeManager;
    }
}