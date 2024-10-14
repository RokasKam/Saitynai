using HikingInforamtionSystemCore.Requests.Point;
using HikingInforamtionSystemCore.Responses.Point;

namespace HikingInforamtionSystemCore.Interfaces.Service;

public interface IPointService
{
    PointResponse GetPointById(Guid id);
    IEnumerable<PointResponse> GetPoints();
    Guid AddPoint(PointRequest pointRequest);
    bool UpdatePoint(Guid id, PointRequest pointRequest);
    bool DeletePoint(Guid id);
}