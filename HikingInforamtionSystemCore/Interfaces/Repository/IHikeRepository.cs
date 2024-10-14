using HikingInformationSystemDomain.Entities;

namespace HikingInforamtionSystemCore.Interfaces;

public interface IHikeRepository
{
    Hike? GetHikeById(Guid id);
    IEnumerable<Hike> GetHikes();
    bool DeleteHike(Guid id);
    Guid AddHike(Hike hike);
    bool UpdateHike(Hike hike);
    bool HikeExists(Guid id);
}