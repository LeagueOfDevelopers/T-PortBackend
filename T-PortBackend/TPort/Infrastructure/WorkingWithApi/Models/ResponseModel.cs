using System.Collections.Generic;

namespace TPort.Infrastructure.WorkingWithApi.Models
{
    public class ResponseModel
    {
        public bool Success { get; set; }
        
        public List<DataModel> Data { get; set; }
    }
}