using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TPort.Domain.RouteManagement;
using TPortApi.Models;

namespace TPortApi.Controllers
{
    public class RoutesController : Controller
    {
        [HttpPost]
        [Route("route")]
        public ActionResult BuildRoute([FromBody] RequestRoute requestRoute)
        {
            return Ok(new ResponseRoute(
                requestRoute.DepartDate,
                DateTimeOffset.Now,
                new List<RouteSegment>(),
                10000));
        }
    }
}