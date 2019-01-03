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
        
        public IEnumerable<FullTrip> FindRoutes(string departureCityCode, string destinationCityCode,
            DateTime departDate)
        {
            var airTickets = _airTicketManager.GetRelevantTickets(departureCityCode, destinationCityCode, departDate);

            var counter = 0;
            var fullTrips = airTickets?.Select(ticket => new FullTrip(new List<Route>
                {
                    new Route(counter++,
                        TransportationType.Airplane,
                        ticket.value,
                        ticket.destination,
                        DateTime.Parse(ticket.depart_date),
                        departDate.AddMinutes(ticket.duration))
                },
                counter,
                new Trip(counter,
                    departureCityCode,
                    destinationCityCode,
                    ticket.value,
                    ticket.duration))).ToList();
            return fullTrips;
        }

        private readonly AirTicketManager _airTicketManager;
    }
}