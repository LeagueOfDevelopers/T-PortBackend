using System;
using System.Collections.Generic;

namespace TPort.Domain.RouteManagement
{
    public class Trip
    {        
        public Trip(Guid id, Destination destination, List<Route> routes, double cost, bool isBooked)
        {
            Id = id;
            Destination = destination ?? throw new ArgumentNullException(nameof(destination));
            _routes = routes ?? throw new ArgumentNullException(nameof(routes));
            Cost = cost;
            IsBooked = isBooked;
        }

        public Guid Id { get; }
        
        public Destination Destination { get; }
        
        public IEnumerable<Route> Routes => _routes;
        
        public double Cost { get; }
        
        public bool IsBooked { get; private set; }

        public void Book()
        {
            IsBooked = true;
        }
        
        private readonly List<Route> _routes;
       
        protected bool Equals(Trip other)
        {
            return Id.Equals(other.Id);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Trip) obj);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}