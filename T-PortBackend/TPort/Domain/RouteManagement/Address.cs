using System;

namespace TPort.Domain.RouteManagement
{
    public class Address
    {
        public Address(City city, Coordinates coordinates)
        {
            City = city ?? throw new ArgumentNullException(nameof(city));
            Coordinates = coordinates ?? throw new ArgumentNullException(nameof(coordinates));
        }

        public City City { get; }
        
        public Coordinates Coordinates { get; }
    }
}