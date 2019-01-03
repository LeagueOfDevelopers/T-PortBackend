using System;

namespace TPort.Infrastructure.WorkingWithApi.Models
{
    public class TicketData
    {
        public int value { get; set; }
        
        public int trip_class { get; set; }
        
        public bool show_to_affiliates { get; set; }
        
        public string origin { get; set; }
        
        public int number_of_changes { get; set; }
        
        public DateTime found_at { get; set; }
        
        public int duration { get; set; }
        
        public int distance { get; set; }
        
        public string destination { get; set; }
        
        public string depart_date { get; set; }
        
        public bool actual { get; set; }
    }
}