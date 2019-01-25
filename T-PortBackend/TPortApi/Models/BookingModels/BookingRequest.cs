using System;

namespace TPortApi.Models.BookingModels
{
    public class BookingRequest
    {
        public Guid UserId { get; set; }
        
        public Guid RouteId { get; set; }
    }
}