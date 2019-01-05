using System.Collections.Generic;

namespace TPort.Infrastructure.WorkingWithApi.Models
{
    public class ApiResponseModel
    {
        public bool Success { get; set; }
        
        public List<TicketData> Data { get; set; }
    }
}