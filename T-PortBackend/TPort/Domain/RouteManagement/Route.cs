using System;

namespace TPort.Domain.RouteManagement
{
    public class Route
    {
        public Route(int id, TransportationType type, int cost, Destination destination, DateTimeOffset departureDate,
            DateTimeOffset arrivalDate)
        {
            Id = id;
            Type = type;
            Cost = cost;
            Destination = destination ?? throw new ArgumentNullException(nameof(destination));
            DepartureDate = departureDate;
            ArrivalDate = arrivalDate;
        }

        public int Id { get; }
        
        public TransportationType Type { get; }
        
        public int Cost { get; }
        
        public Destination Destination { get; }
        
        public DateTimeOffset DepartureDate { get; }
        
        public DateTimeOffset ArrivalDate { get; }
    }
}