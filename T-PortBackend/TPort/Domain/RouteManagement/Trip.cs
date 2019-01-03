using System;

namespace TPort.Domain.RouteManagement
{
    public class Trip
    {
        public Trip(int id, string departureCityCode, string destinationCityCode, int cost, int duration)
        {
            Id = id;
            DepartureCityCode = departureCityCode ?? throw new ArgumentNullException(nameof(departureCityCode));
            DestinationCityCode = destinationCityCode ?? throw new ArgumentNullException(nameof(destinationCityCode));
            Cost = cost;
            Duration = duration;
        }

        public int Id { get; }
        
        public string DepartureCityCode { get; }
        
        public string DestinationCityCode { get; }
        
        //public City DepartureCity { get; }
        
        //public City DestinationCity { get; }
        
        public int Cost { get; }
        
        public int Duration { get; } // пока в минутах
    }
}