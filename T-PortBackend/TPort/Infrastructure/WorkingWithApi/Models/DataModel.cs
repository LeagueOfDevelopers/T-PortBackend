using System;

namespace TPort.Infrastructure.WorkingWithApi.Models
{
    public class DataModel
    {
        public int Value { get; set; }
        public int TripClass { get; set; }
        public bool show_to_affiliates { get; set; }
        public string return_date { get; set; }
        public string origin { get; set; }
        public int number_of_changes { get; set; }
        public string gate { get; set; }
        public DateTime found_at { get; set; }
        public int duration { get; set; }
        public int distance { get; set; }
        public string destination { get; set; }
        public string depart_date { get; set; }
        public bool actual { get; set; }
    }
}