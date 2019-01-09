using System;
using System.Collections.Generic;
using TPort.Domain.Exceptions;
using TPort.Domain.RouteManagement;

namespace TPort.Infrastructure.DataAccess
{
    public class InMemoryPlaceRepository : IPlaceRepository
    {
        public InMemoryPlaceRepository(List<Place> places)
        {
            _places = places ?? throw new ArgumentNullException(nameof(places));
        }

        public List<Place> Places => _places;

        public Place GetPlaceByName(string name)
        {
            return _places.Find(place => place.Name == name) ??
                   throw new NonexistentCityException($"City with name {name} not found");
        }

        public Place GetPlaceByIata(string iataCode)
        {
            return _places.Find(city => city.IataCode == iataCode) ?? 
                throw new NonexistentCityException($"City with IATA code {iataCode} not found");
        }

        private readonly List<Place> _places;
    }
}