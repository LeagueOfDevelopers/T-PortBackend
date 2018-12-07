using System;
using System.Collections.Generic;

namespace TPortApi.Models.RouteModels
{
    public class ResponseRoute
    {
        public ResponseRoute(DateTimeOffset departDate, DateTimeOffset arrivalDate,
            IEnumerable<RouteSegment> routeSegments, int price)
        {
            DepartDate = departDate;
            ArrivalDate = arrivalDate;
            RouteSegments = routeSegments ?? throw new ArgumentNullException(nameof(routeSegments));
            Price = price;
        }

        public DateTimeOffset DepartDate { get; }
        
        public DateTimeOffset ArrivalDate { get; }
        
        public IEnumerable<RouteSegment> RouteSegments { get; }
        
        public int Price { get; }
    }
}