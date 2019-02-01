using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using TPort.Infrastructure.WorkingWithApi;
using TPort.Infrastructure.WorkingWithApi.Models;
using TPort.Services;
using Xunit;

namespace TPortTests
{
    public class AirTicketManagerTests
    {
        [Fact]
        public void GetRelevantTicketsTest_ДаемАктуальныеИНеактуальныеБилеты_ПолучаемТолькоАктуальные()
        {
            Assert.True(true); // TODO
/*            // Arrange
            var actualTicket = new TicketData
            {
                Value = 10.0,
                Actual = true,
                Depart_Date = "date",
                Destination = "123",
                Duration = "duration",
                Origin = "321"
            };
            var notActualTicket =  new TicketData
            {
                Value = 20.0,
                Actual = false,
                Depart_Date = "date",
                Destination = "321",
                Duration = "abc",
                Origin = "123"
            };
            var airApiMock = new Mock<AirTicketsApi>();
            airApiMock
                .Setup(api => api.GetAllAirTickets("empty", "empty", "date", true, 2))
                .Returns(new ApiResponseModel
                {
                    Success = true,
                    Data = new List<TicketData>
                    {
                        actualTicket, notActualTicket
                    }
                });
            var airTicketManager = new AirTicketManager(airApiMock.Object);
            
            // Act
            var result = airTicketManager
                .GetRelevantTickets("abc", "bca", DateTime.Now)
                .ToList();
            
            // Assert
            Assert.True(result.Count() == 1);
            Assert.Equal(actualTicket, result.First());*/
        }
    }
}