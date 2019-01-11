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
        public RouteManager(AirTicketManager airTicketManager, IPlaceRepository cityRepository)
        {
            _airTicketManager = airTicketManager ?? throw new ArgumentNullException(nameof(airTicketManager));
            _placeRepository = cityRepository ?? throw new ArgumentNullException(nameof(cityRepository));
        }
        
        public IEnumerable<Trip> FindRoutes(string departureCityName, string destinationCityName,
            DateTime departDate)
        {
            var airTickets = _airTicketManager.GetRelevantTickets(
                _placeRepository.GetPlaceByName(departureCityName)?.IataCode ??
                    throw new NonexistentCityException($"City with name {departureCityName} not found"),
                _placeRepository.GetPlaceByName(destinationCityName)?.IataCode ??
                    throw new NonexistentCityException($"City with name {destinationCityName} not found"),
                departDate);

            var trips = airTickets?.Select(ticket => new Trip(Guid.NewGuid(),
                new Destination(_placeRepository.GetPlaceByIata(ticket.Origin),
                    _placeRepository.GetPlaceByIata(ticket.Destination)),
                new List<Route>
                {
                    new Route(Guid.NewGuid(),
                        new Transport("Боинг-737", TransportationType.Airplane),
                        ticket.Value,
                        new Destination(_placeRepository.GetPlaceByIata(ticket.Origin),
                            _placeRepository.GetPlaceByIata(ticket.Destination)),
                        DateTime.Parse(ticket.Depart_Date),
                        departDate.AddMinutes(Convert.ToInt32(ticket.Duration)))
                },
                ticket.Value));
            return trips;
        }

        private readonly IPlaceRepository _placeRepository;
        private readonly AirTicketManager _airTicketManager;
    }
}