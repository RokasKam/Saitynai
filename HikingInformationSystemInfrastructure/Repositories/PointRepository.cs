using HikingInforamtionSystemCore.Interfaces;
using HikingInformationSystemDomain.Entities;
using HikingInformationSystemInfrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HikingInformationSystemInfrastructure.Repositories;

public class PointRepository : IPointRepository
{
    private readonly HikingInformationSystemDataContext _context;

    public PointRepository(HikingInformationSystemDataContext context)
    {
        _context = context;
    }

    public Point? GetPointById(Guid id)
    {
        return _context.Points
            .Include(p=>p.Route)
            .ThenInclude(r=>r.Hike)
            .FirstOrDefault(p => p.Id == id);
    }

    public IEnumerable<Point> GetPoints()
    {
        return _context.Points.ToList();
    }

    public bool DeletePoint(Guid id)
    {
        _context.Points.Where(p => p.Id == id).ExecuteDelete();
        _context.SaveChanges();
        return true;
    }

    public Guid AddPoint(Point point)
    {
        point.Id = Guid.NewGuid();
        _context.Points.Add(point);
        _context.SaveChanges();
        return point.Id;
    }

    public bool UpdatePoint(Point point)
    {
        _context.Points.Update(point);
        _context.SaveChanges();
        return true;
    }

    public bool PointExists(Guid id)
    {
        return _context.Points.Any(p => p.Id == id);
    }

    public IEnumerable<Point> GetPointsByRouteId(Guid routeId)
    {
        return _context.Points.Where(p => p.RouteId == routeId);
    }
}