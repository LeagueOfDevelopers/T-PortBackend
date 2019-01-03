using System;
using TPort.Domain.Exceptions;
using TPort.Domain.RouteManagement;
using TPort.Infrastructure.DataAccess;

namespace TPort.Services
{
    public class CityManager
    {
        public CityManager(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository ?? throw new ArgumentNullException(nameof(cityRepository));
        }

        public City FindCity(string cityName)
        {
            var city = _cityRepository.GetCityByName(cityName);
            
            return city ?? throw new NonexistentCityException($"City with name {cityName} not found");
        }
        
        private readonly ICityRepository _cityRepository;
    }
}