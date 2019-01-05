using System;
using System.Collections.Generic;
using System.Linq;
using TPort.Infrastructure.WorkingWithApi;
using TPort.Infrastructure.WorkingWithApi.Models;

namespace TPort.Services
{
    public class AirTicketManager
    {
        public AirTicketManager(AirTicketsApi airTicketsApi)
        {
            _airTicketsApi = airTicketsApi ?? throw new ArgumentNullException(nameof(airTicketsApi));
        }

        public IEnumerable<TicketData> GetRelevantTickets(string originCode, string destinationCode, DateTime departureDate)
        {
            var beginningPeriod = departureDate.AddDays(-(departureDate.Day - 1));
            var tickets = _airTicketsApi.GetAllAirTickets(originCode,
                destinationCode,
                beginningPeriod.Date.ToString("yyyy-MM-dd")).Data;
            
            return tickets?.Where(ticket => ticket.Actual);
            
                //&& DateTime.Parse(ticket.depart_date).Date == departureDate.Date
        }
        
        private readonly AirTicketsApi _airTicketsApi;
    }
}