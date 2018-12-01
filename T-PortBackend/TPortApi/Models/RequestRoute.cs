using System;
using System.ComponentModel.DataAnnotations;
using TPort.Domain.RouteManagement;

namespace TPortApi.Models
{
    public class RequestRoute
    {
        public RequestRoute(Guid userId, Address origin, Address destination, DateTimeOffset departDate)
        {
            UserId = userId;
            Origin = origin ?? throw new ArgumentNullException(nameof(origin));
            Destination = destination ?? throw new ArgumentNullException(nameof(destination));
            DepartDate = departDate;
        }
        
        [Required]
        public Guid UserId { get; }

        [Required]
        public Address Origin { get; }
        
        [Required]
        public Address Destination { get; }
        
        [Required]
        public DateTimeOffset DepartDate { get; }
    }
}