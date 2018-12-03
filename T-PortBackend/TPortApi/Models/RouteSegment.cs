using System;
using TPort.Domain.RouteManagement;

namespace TPortApi.Models
{
    public class RouteSegment
    {
        public string VehicleType { get; }
        
        public Address Origin { get; }
        
        public Address Destination { get; }
        
        public DateTimeOffset DepartDate { get; }
        
        public DateTimeOffset ArrivalDate { get; }
        
        public int Price { get; }
    }
}