using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace TPortApi.Models.RouteModels
{
    [JsonObject]
    public class RequestRoute
    {
        [Required]
        [JsonProperty("departureCityName")]
        public string DepartureCityName { get; set; }
        
        [Required]
        [JsonProperty("destinationCityName")]
        public string DestinationCityName { get; set; }
        
        [Required]
        [JsonProperty("departDate")]
        public DateTime DepartDate { get; set; }
    }
}