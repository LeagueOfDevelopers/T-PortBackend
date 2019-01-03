using System;
using System.Collections.Generic;
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
            return _cities.Find(city => city.Name == name);
        }

        private readonly List<City> _cities;
    }
}