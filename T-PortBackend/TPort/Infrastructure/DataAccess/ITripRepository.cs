using System;
using TPort.Domain.RouteManagement;

namespace TPort.Infrastructure.DataAccess
{
    public interface ITripRepository
    {
        void SaveTrip(Trip trip);

        Trip LoadTrip(Guid tripId);
    }
}