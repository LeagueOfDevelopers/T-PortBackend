using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TPort.Services;

using TPortApi.Models.RouteModels;
using TPortApi.Security;

namespace TPortApi.Controllers
{
    public class TripController : Controller
    {
        [HttpGet]
        [Route("trips")]
        public ActionResult FindTrips([FromQuery] RequestRoute requestRoute)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [Route("trips/{tripId}/booking")]
        [Authorize]
        public ActionResult BookTrip(Guid tripId)
        {
            throw new NotImplementedException();
        }
    }
}