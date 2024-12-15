using HikingInforamtionSystemCore.Requests.Route;
using HikingInforamtionSystemCore.Responses.Route;

namespace HikingInforamtionSystemCore.Interfaces.Service;

public interface IRouteService
{
    RouteResponse GetRouteById(Guid id);
    IEnumerable<RouteResponse> GetRoutes();
    RouteWithPointsResponse GetRouteWithPoints(Guid routeId);
    Guid AddRoute(RouteRequest routeRequest);
    bool UpdateRoute(Guid id, RouteRequest routeRequest, string userId);
    bool DeleteRoute(Guid id, string userId);
}