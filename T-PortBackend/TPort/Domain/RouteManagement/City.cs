using System;

namespace TPort.Domain.RouteManagement
{
    public class City
    {
        public City(string region, string city, string iataCode)
        {
            Region = region ?? throw new ArgumentNullException(nameof(region));
            Name = city ?? throw new ArgumentNullException(nameof(city));
            IataCode = iataCode;
        }

        public string Region { get; }
        
        public string Name { get; }
        
        public string IataCode { get; }
    }
}