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
        return _context.Routes.FirstOrDefault(h => h.Id == id);
    }

    public IEnumerable<Route> GetRoutes()
    {
        return _context.Routes.ToList();
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
        _context.Routes.Update(route);
        _context.SaveChanges();
        return true;
    }

    public bool RouteExists(Guid id)
    {
        return _context.Routes.Any(r=> r.Id == id);
    }
}