using System;
using System.Collections.Generic;
using System.Linq;
using TPort.Domain.RouteManagement;

namespace TPort.Services
{
    public class RouteManager
    {
        public RouteManager(AirTicketManager airTicketManager)
        {
            _airTicketManager = airTicketManager ?? throw new ArgumentNullException(nameof(airTicketManager));
        }
        
        public IEnumerable<Trip> FindRoutes(string departureCityCode, string destinationCityCode,
            DateTime departDate)
        {
            var airTickets = _airTicketManager.GetRelevantTickets(departureCityCode, destinationCityCode, departDate);

            var trips = airTickets?.Select(ticket => new Trip(Guid.NewGuid(),
                ticket.Origin,
                ticket.Destination,
                new List<Route>
                {
                    new Route(Guid.NewGuid(),
                        TransportationType.Airplane,
                        ticket.Value,
                        ticket.Destination,
                        DateTime.Parse(ticket.Depart_Date),
                        departDate.AddMinutes(ticket.Duration))
                }, 
                ticket.Value, 
                TimeSpan.FromMinutes(ticket.Duration)));
            return trips;
        }

        private readonly AirTicketManager _airTicketManager;
    }
}