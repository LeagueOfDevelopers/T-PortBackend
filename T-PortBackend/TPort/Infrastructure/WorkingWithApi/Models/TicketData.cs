namespace TPort.Infrastructure.WorkingWithApi.Models
{
    public class TicketData
    {
        public double Value { get; set; }
        public string Origin { get; set; }
        public string Duration { get; set; }
        public string Destination { get; set; }
        public string Depart_Date { get; set; }
        public bool Actual { get; set; }
    }
}