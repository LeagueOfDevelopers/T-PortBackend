using System;

namespace TPort.Domain.RouteManagement
{
    public class RouteSegment
    {
        public RouteSegment(Guid id, Address departureAddress, Address arrivalAddress, TransportationType type,
            DateTimeOffset departureDate, DateTimeOffset arrivalDate)
        {
            Id = id;
            DepartureAddress = departureAddress ?? throw new ArgumentNullException(nameof(departureAddress));
            ArrivalAddress = arrivalAddress ?? throw new ArgumentNullException(nameof(arrivalAddress));
            Type = type;
            DepartureDate = departureDate;
            ArrivalDate = arrivalDate;
        }

        public Guid Id { get; }
        
        public Address DepartureAddress { get; }
        
        public Address ArrivalAddress { get; }
        
        public TransportationType Type { get; }
        
        public DateTimeOffset DepartureDate { get; }
        
        public DateTimeOffset ArrivalDate { get; }
    }
}