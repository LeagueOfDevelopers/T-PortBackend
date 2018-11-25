using System;

namespace TPortApi.Models
{
    public class Address
    {
        public Address(string countryName, string regionName, string cityName, string streetName, string houseName)
        {
            CountryName = countryName ?? throw new ArgumentNullException(nameof(countryName));
            RegionName = regionName ?? throw new ArgumentNullException(nameof(regionName));
            CityName = cityName ?? throw new ArgumentNullException(nameof(cityName));
            StreetName = streetName ?? throw new ArgumentNullException(nameof(streetName));
            HouseName = houseName ?? throw new ArgumentNullException(nameof(houseName));
        }

        public string CountryName { get; }
        
        public string RegionName { get; }
        
        public string CityName { get; }
        
        public string StreetName { get; }
        
        public string HouseName { get; }
    }
}