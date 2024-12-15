using HikingInforamtionSystemCore.Interfaces;
using HikingInformationSystemDomain.Entities;
using HikingInformationSystemInfrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HikingInformationSystemInfrastructure.Repositories;

public class RouteRepository : IRouteRepository
{
    private readonly HikingInformationSystemDataContext _context;

    public RouteRepository(HikingInformationSystemDataContext context)
    {
        _context = context;
    }

    public Route? GetRouteById(Guid id)
    {
        return _context.Routes
            .Include(r=>r.Hike) 
            .FirstOrDefault(r => r.Id == id);
    }

    public IEnumerable<Route> GetRoutes()
    {
        return _context.Routes.ToList();
    }

    public IEnumerable<Route> GetRoutesByHikeId(Guid hikeId)
    {
        return _context.Routes.Where(r => r.HikeId == hikeId).ToList();
    }

    public bool DeleteRoute(Guid id)
    {
        _context.Routes.Where(h => h.Id == id).ExecuteDelete();
        _context.SaveChanges();
        return true;
    }

    public Guid AddRoute(Route route)
    {
        route.Id = Guid.NewGuid();
        _context.Routes.Add(route);
        _context.SaveChanges();
        return route.Id;
    }

    public bool UpdateRoute(Route route)
    {
        var existingRoute = _context.Routes.FirstOrDefault(r => r.Id == route.Id);
        if (existingRoute != null)
        {
            _context.Entry(existingRoute).State = EntityState.Detached;
        }

        _context.Routes.Attach(route);
        _context.Entry(route).State = EntityState.Modified;

        _context.SaveChanges();
        return true;
    }


    public bool RouteExists(Guid id)
    {
        return _context.Routes.Any(r=> r.Id == id);
    }
}