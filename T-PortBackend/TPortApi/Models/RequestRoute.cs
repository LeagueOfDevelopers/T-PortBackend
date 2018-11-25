using System;
using System.ComponentModel.DataAnnotations;

namespace TPortApi.Models
{
    public class RequestRoute
    {
        public RequestRoute(Address origin, Address destination, DateTimeOffset departDate)
        {
            Origin = origin ?? throw new ArgumentNullException(nameof(origin));
            Destination = destination ?? throw new ArgumentNullException(nameof(destination));
            DepartDate = departDate;
        }

        [Required]
        public Address Origin { get; }
        
        [Required]
        public Address Destination { get; }
        
        [Required]
        public DateTimeOffset DepartDate { get; }
    }
}