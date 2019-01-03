using System;

namespace TPort.Domain.RouteManagement
{
    public class Route
    {
        public Route(int id, TransportationType type, int cost, string destinationCode, DateTime departureDate,
            DateTime arrivalDate)
        {
            Id = id;
            Type = type;
            Cost = cost;
            DestinationCode = destinationCode ?? throw new ArgumentNullException(nameof(destinationCode));
            DepartureDate = departureDate;
            ArrivalDate = arrivalDate;
        }

        public int Id { get; }
        
        public TransportationType Type { get; }
        
        public int Cost { get; }
        
        public string DestinationCode { get; }
        
        //public Destination Destination { get; }
        
        public DateTime DepartureDate { get; }
        
        public DateTime ArrivalDate { get; }
    }
}