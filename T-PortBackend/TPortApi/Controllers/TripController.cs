using System;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TPort.Services;
using TPortApi.Extensions;
using TPortApi.Models.AccountModels;
using TPortApi.Models.RouteModels;

namespace TPortApi.Controllers
{
    public class TripController : Controller
    {
        public TripController(TripManager tripManager, AccountManager accountManager)
        {
            _tripManager = tripManager ?? throw new ArgumentNullException(nameof(tripManager));
            _accountManager = accountManager ?? throw new ArgumentNullException(nameof(accountManager));
        }

        [HttpGet]
        [Route("trips")]
        public ActionResult FindTrips([FromQuery] RequestRoute requestRoute)
        {
            return Ok(_tripManager
                .FindTrips(requestRoute.DepartureCityName, requestRoute.DestinationCityName, requestRoute.DepartDate));
        }

        [HttpPost]
        [Route("trips/{tripId}/booking")]
        [Authorize]
        public ActionResult BookTrip(Guid tripId)
        {
            var userId = Request.GetUserId();
            _tripManager.BookTrip(tripId);
            _accountManager.AddTripToAccount(tripId, userId);
            return Ok();
        }
        
        private readonly TripManager _tripManager;
        private readonly AccountManager _accountManager;
    }
}