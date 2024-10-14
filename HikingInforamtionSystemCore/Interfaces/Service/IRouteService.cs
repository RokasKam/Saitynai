using HikingInforamtionSystemCore.Requests.Route;
using HikingInforamtionSystemCore.Responses.Route;

namespace HikingInforamtionSystemCore.Interfaces.Service;

public interface IRouteService
{
    RouteResponse GetRouteById(Guid id);
    RouteWithPointsResponse GetRouteWithPointsById(Guid id);
    IEnumerable<RouteResponse> GetRoutes();
    Guid AddRoute(RouteRequest routeRequest);
    bool UpdateRoute(Guid id, RouteRequest routeRequest);
    bool DeleteRoute(Guid id);
}