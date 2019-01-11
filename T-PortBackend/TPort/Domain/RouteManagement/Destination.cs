using System;

namespace TPort.Domain.RouteManagement
{
    public class Destination
    {
        public Destination(Place fromPlace, Place toPlace)
        {
            FromPlace = fromPlace ?? throw new ArgumentNullException(nameof(fromPlace));
            ToPlace = toPlace ?? throw new ArgumentNullException(nameof(toPlace));
        }

        public Place FromPlace { get; }

        public Place ToPlace { get; }
    }
}