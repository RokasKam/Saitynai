using HikingInformationSystemDomain.Entities;

namespace HikingInforamtionSystemCore.Interfaces;

public interface IPointRepository
{
    Point? GetPointById(Guid id);
    IEnumerable<Point> GetPoints();
    bool DeletePoint(Guid id);
    Guid AddPoint(Point point);
    bool UpdatePoint(Point point);
    bool PointExists(Guid id);
    IEnumerable<Point> GetPointsByRouteId(Guid routeId);
}