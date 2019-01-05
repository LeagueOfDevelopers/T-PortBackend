using System;
using System.ComponentModel.DataAnnotations;

namespace TPortApi.Models.RouteModels
{
    public class RequestRoute
    {
        [Required]
        public string DepartureCityCode { get; set; }
        
        [Required]
        public string DestinationCityCode { get; set; }
        
        [Required]
        public DateTime DepartDate { get; set; }
    }
}