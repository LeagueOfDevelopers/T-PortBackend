using TPort.Domain.RouteManagement;

namespace TPort.Infrastructure.DataAccess
{
    public interface ICityRepository
    {
        City GetCityByName(string name);
    }
}