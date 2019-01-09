using TPort.Domain.RouteManagement;

namespace TPort.Infrastructure.DataAccess
{
    public interface IPlaceRepository
    {
        Place GetPlaceByName(string name);
        
        Place GetPlaceByIata(string iataCode);
    }
}