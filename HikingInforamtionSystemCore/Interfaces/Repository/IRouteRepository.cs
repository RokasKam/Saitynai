using HikingInformationSystemDomain.Entities;

namespace HikingInforamtionSystemCore.Interfaces;

public interface IRouteRepository
{
    Route? GetRouteById(Guid id);
    IEnumerable<Route> GetRoutes();
    IEnumerable<Route> GetRoutesByHikeId(Guid hikeId);
    bool DeleteRoute(Guid id);
    Guid AddRoute(Route route);
    bool UpdateRoute(Route route);
    bool RouteExists(Guid id);
}