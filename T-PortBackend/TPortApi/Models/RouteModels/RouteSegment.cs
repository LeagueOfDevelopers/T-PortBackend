using System;
using TPort.Domain.RouteManagement;

namespace TPortApi.Models.RouteModels
{
    public class RouteSegment
    {
        public string VehicleType { get; set; }
        
        public Address Origin { get; set; }
        
        public Address Destination { get; set; }
        
        public DateTimeOffset DepartDate { get; set; }
        
        public DateTimeOffset ArrivalDate { get; set; }
        
        public int Price { get; set; }
    }
}