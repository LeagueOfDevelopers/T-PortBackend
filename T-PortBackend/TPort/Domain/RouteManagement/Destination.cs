using System;

namespace TPort.Domain.RouteManagement
{
    public class Destination
    {
        public Destination(Address departureAddress, Address destinationAddress)
        {
            DepartureAddress = departureAddress ?? throw new ArgumentNullException(nameof(departureAddress));
            DestinationAddress = destinationAddress ?? throw new ArgumentNullException(nameof(destinationAddress));
        }

        public Address DepartureAddress { get; }
        
        public Address DestinationAddress { get; }
    }
}