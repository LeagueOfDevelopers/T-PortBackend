using System;
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

        public ResponseModel GetAllTickets(string originCode, string destinationCode, DateTime departureDate)
        {
            var beginningPeriod = departureDate.AddDays(-(departureDate.Day - 1));
            var tickets = _airTicketsApi.GetAllAirTickets(originCode, destinationCode, beginningPeriod.Date.ToString("yyyy-MM-dd"));
            return tickets.Result;
        }
        
        private readonly AirTicketsApi _airTicketsApi;
    }
}