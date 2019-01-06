using System;

namespace TPort.Domain.RouteManagement
{
    public class Route
    {
        public Route(Guid id, TransportationType type, double cost, City origin, City destination,DateTime departureDate,
            DateTime arrivalDate)
        {
            Id = id;
            Type = type;
            Cost = cost;
            Origin = origin ?? throw new ArgumentNullException(nameof(origin));
            Destination = destination ?? throw new ArgumentNullException(nameof(destination));
            DepartureDate = departureDate;
            ArrivalDate = arrivalDate;
        }

        public Guid Id;
        
        public TransportationType Type { get; }
        
        public double Cost { get; }
        
        public City Origin { get; }   //пока так
        
        public City Destination { get; }
        
        public DateTime DepartureDate { get; }
        
        public DateTime ArrivalDate { get; }
    }
}