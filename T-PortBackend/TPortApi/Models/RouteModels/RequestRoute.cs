using System;
using System.ComponentModel.DataAnnotations;
using TPort.Domain.RouteManagement;

namespace TPortApi.Models.RouteModels
{
    public class RequestRoute
    {
        [Required]
        public string DepartureCity { get; set; }
        
        [Required]
        public string DestinationCity { get; set; }
        
        [Required]
        public DateTimeOffset DepartDate { get; set; }
    }
}