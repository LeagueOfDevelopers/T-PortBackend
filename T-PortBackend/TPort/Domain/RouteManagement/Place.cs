using System;

namespace TPort.Domain.RouteManagement
{
    public class Place
    {
        public Place(string region, string name, string iataCode, Coordinates coordinates)
        {
            Region = region ?? throw new ArgumentNullException(nameof(region));
            Name = name ?? throw new ArgumentNullException(nameof(name));
            IataCode = iataCode;
            Coordinates = coordinates;
        }

        public string Name { get; }
        
        public string Region { get; }
        
        public string IataCode { get; }
        
        public Coordinates Coordinates { get; }
    }
}