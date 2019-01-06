using System;
using System.Collections.Generic;
using System.Linq;
using TPort.Domain.Exceptions;
using TPort.Domain.RouteManagement;
using TPort.Infrastructure.DataAccess;

namespace TPort.Services
{
    public class RouteManager
    {
        public RouteManager(AirTicketManager airTicketManager, ICityRepository cityRepository)
        {
            _airTicketManager = airTicketManager ?? throw new ArgumentNullException(nameof(airTicketManager));
            _cityRepository = cityRepository ?? throw new ArgumentNullException(nameof(cityRepository));
        }
        
        public IEnumerable<Trip> FindRoutes(string departureCityName, string destinationCityName,
            DateTime departDate)
        {
            var airTickets = _airTicketManager.GetRelevantTickets(
                _cityRepository.GetCityByName(departureCityName)?.IataCode ??
                    throw new NonexistentCityException($"City with name {departureCityName} not found"),
                _cityRepository.GetCityByName(destinationCityName)?.IataCode ??
                    throw new NonexistentCityException($"City with name {destinationCityName} not found"),
                departDate);

            var trips = airTickets?.Select(ticket => new Trip(Guid.NewGuid(),
                _cityRepository.GetCityByIata(ticket.Origin),
                _cityRepository.GetCityByIata(ticket.Destination),
                new List<Route>
                {
                    new Route(Guid.NewGuid(),
                        TransportationType.Airplane,
                        ticket.Value,
                        _cityRepository.GetCityByIata(ticket.Origin),
                        _cityRepository.GetCityByIata(ticket.Destination),
                        DateTime.Parse(ticket.Depart_Date),
                        departDate.AddMinutes(Convert.ToInt32(ticket.Duration)))
                },
                ticket.Value,
                TimeSpan.FromMinutes(Convert.ToInt32(ticket.Duration))));
            return trips;
        }

        private readonly ICityRepository _cityRepository;
        private readonly AirTicketManager _airTicketManager;
    }
}