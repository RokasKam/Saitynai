using HikingInforamtionSystemCore.Requests.Hike;
using HikingInforamtionSystemCore.Responses.Hike;

namespace HikingInforamtionSystemCore.Interfaces.Service;

public interface IHikeService
{
    HikeResponse GetHikeById(Guid id);
    IEnumerable<HikeResponse> GetHikes();
    HikeWithSpecificRouteAndPoints GetHikeWithSpecificRouteAndPoints(Guid routeId, Guid hikeId);
    Guid AddHike(HikeRequest hikeRequest, string userId);
    bool UpdateHike(Guid id, HikeRequest hikeRequest);
    bool DeleteHike(Guid id);
}