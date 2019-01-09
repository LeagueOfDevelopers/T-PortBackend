using System;

namespace TPort.Domain.RouteManagement
{
    public class Route
    {
        public Route(Guid id, Transport transport, double cost, Destination destination,DateTime departureDate,
            DateTime arrivalDate)
        {
            Id = id;
            Transport = transport;
            Cost = cost;
            Destination = destination ?? throw new ArgumentNullException(nameof(destination));
            DepartureDate = departureDate;
            ArrivalDate = arrivalDate;
        }

        public Guid Id;
        
        public Transport Transport { get; }
        
        public double Cost { get; }
        
        public Destination Destination { get; }
        
        public DateTime DepartureDate { get; }
        
        public DateTime ArrivalDate { get; }
        
        public bool IsPaid { get; private set; }

        public void Pay()
        {
            IsPaid = true;
        }   
    }
}