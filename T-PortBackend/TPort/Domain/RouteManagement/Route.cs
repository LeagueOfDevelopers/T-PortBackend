using System;
using System.Collections.Generic;
using System.Linq;

namespace TPort.Domain.RouteManagement
{
    public class Route
    {
        public Route(Guid id, Address departureAddress, Address arrivalAddress, List<RouteSegment> routeSegments)
        {
            Id = id;
            DepartureAddress = departureAddress ?? throw new ArgumentNullException(nameof(departureAddress));
            ArrivalAddress = arrivalAddress ?? throw new ArgumentNullException(nameof(arrivalAddress));
            _routeSegments = routeSegments ?? throw new ArgumentNullException(nameof(routeSegments));
        }

        public Guid Id { get; }
        
        public Address DepartureAddress { get; }
        
        public Address ArrivalAddress { get; }

        public IEnumerable<RouteSegment> RouteSegments => _routeSegments;

        public DateTimeOffset GetDepartureDate()
        {
            return _routeSegments.First().DepartureDate;
        }

        public DateTimeOffset GetArrivalDate()
        {
            return _routeSegments.Last().ArrivalDate;
        }
        
        private readonly List<RouteSegment> _routeSegments;
    }
}