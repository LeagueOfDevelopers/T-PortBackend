using System;
using System.Collections.Generic;
using TPort.Domain.Exceptions;
using TPort.Domain.RouteManagement;

namespace TPort.Infrastructure.DataAccess
{
    public class InMemoryCityRepository : ICityRepository
    {
        public InMemoryCityRepository(List<City> cities)
        {
            _cities = cities ?? throw new ArgumentNullException(nameof(cities));
        }

        public IEnumerable<City> Cities => _cities;
        
        public City GetCityByName(string name)
        {
            return _cities.Find(city => city.Name == name) ??
                   throw new NonexistentCityException($"City with name {name} not found");
        }

        public City GetCityByIata(string iataCode)
        {
            return _cities.Find(city => city.IataCode == iataCode) ?? 
                throw new NonexistentCityException($"City with IATA code {iataCode} not found");
        }

        private readonly List<City> _cities;
    }
}