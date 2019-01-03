using System;
using System.Collections.Generic;
using TPort.Domain.RouteManagement;

namespace TPort.Services
{
    public class RouteManager
    {
        public IEnumerable<FullTrip> FindRoutes(City departureCity, City destinationCity, DateTimeOffset departDate)
        {
            return new[]
            {
                new FullTrip(new List<Route>
                    {
                        new Route(1,
                            TransportationType.Taxi,
                            1000,
                            new Destination(new Address(departureCity,
                                    new Coordinates(0,
                                        0)),
                                new Address(destinationCity,
                                    new Coordinates(0,
                                        0))),
                            departDate,
                            DateTimeOffset.Now),
                        new Route(2,
                            TransportationType.Airplane,
                            5000,
                            new Destination(new Address(departureCity,
                                    new Coordinates(0,
                                        0)),
                                new Address(destinationCity,
                                    new Coordinates(0,
                                        0))),
                            departDate,
                            DateTimeOffset.Now),
                        new Route(3,
                            TransportationType.Train,
                            4000,
                            new Destination(new Address(departureCity,
                                    new Coordinates(0,
                                        0)),
                                new Address(destinationCity,
                                    new Coordinates(0,
                                        0))),
                            departDate,
                            DateTimeOffset.Now)
                    },
                    1,
                    new Trip(1,
                        departureCity,
                        destinationCity,
                        10000,
                        departDate)),
                new FullTrip(new List<Route>
                    {
                        new Route(4,
                            TransportationType.Train,
                            1000,
                            new Destination(new Address(departureCity,
                                    new Coordinates(0,
                                        0)),
                                new Address(destinationCity,
                                    new Coordinates(0,
                                        0))),
                            departDate,
                            DateTimeOffset.Now),
                        new Route(5,
                            TransportationType.Airplane,
                            5000,
                            new Destination(new Address(departureCity,
                                    new Coordinates(0,
                                        0)),
                                new Address(destinationCity,
                                    new Coordinates(0,
                                        0))),
                            departDate,
                            DateTimeOffset.Now),
                        new Route(6,
                            TransportationType.Taxi,
                            4000,
                            new Destination(new Address(departureCity,
                                    new Coordinates(0,
                                        0)),
                                new Address(destinationCity,
                                    new Coordinates(0,
                                        0))),
                            departDate,
                            DateTimeOffset.Now)
                    },
                    2,
                    new Trip(2,
                        departureCity,
                        destinationCity,
                        10000,
                        departDate))
            };
        }
    }
}