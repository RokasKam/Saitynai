using HikingInforamtionSystemCore.Requests.Hike;
using HikingInforamtionSystemCore.Responses.Hike;

namespace HikingInforamtionSystemCore.Interfaces.Service;

public interface IHikeService
{
    HikeResponse GetHikeById(Guid id);
    IEnumerable<HikeResponse> GetHikes();
    Guid AddHike(HikeRequest hikeRequest);
    bool UpdateHike(Guid id, HikeRequest hikeRequest);
    bool DeleteHike(Guid id);
}