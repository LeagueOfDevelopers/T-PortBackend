using System;
using System.ComponentModel.DataAnnotations;

namespace TPortApi.Models.RouteModels
{
    public class RequestRoute
    {
        [Required]
        public string DepartureCityName { get; set; }
        
        [Required]
        public string DestinationCityName { get; set; }
        
        [Required]
        public DateTime DepartDate { get; set; }
    }
}