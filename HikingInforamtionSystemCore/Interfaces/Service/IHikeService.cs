using HikingInforamtionSystemCore.Requests.Hike;
using HikingInforamtionSystemCore.Responses.Hike;

namespace HikingInforamtionSystemCore.Interfaces.Service;

public interface IHikeService
{
    HikeResponse GetHikeById(Guid id);
    IEnumerable<HikeResponse> GetHikes();
    IEnumerable<HikeResponse> GetHikesByCreatorId(string creatorId);
    HikeWithSpecificRouteAndPoints GetHikeWithSpecificRouteAndPoints(Guid routeId, Guid hikeId);
    HikeWithRoutes GetHikeWithRoutes(Guid hikeId);
    Guid AddHike(HikeRequest hikeRequest, string userId);
    bool UpdateHike(Guid id, HikeRequest hikeRequest, string userId);
    bool DeleteHike(Guid id, string userId);
}