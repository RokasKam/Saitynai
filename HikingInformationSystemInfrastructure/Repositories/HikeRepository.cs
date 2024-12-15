using HikingInforamtionSystemCore.Interfaces;
using HikingInformationSystemDomain.Entities;
using HikingInformationSystemInfrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HikingInformationSystemInfrastructure.Repositories;

public class HikeRepository : IHikeRepository
{
    private readonly HikingInformationSystemDataContext _context;

    public HikeRepository(HikingInformationSystemDataContext context)
    {
        _context = context;
    }

    public Hike? GetHikeById(Guid id)
    {
        return _context.Hikes.FirstOrDefault(h => h.Id == id);
    }

    public IEnumerable<Hike> GetHikes()
    {
        return _context.Hikes.ToList();
    }

    public IEnumerable<Hike> GetHikesByCreator(string creatorId)
    {
        return _context.Hikes.Where(h=> h.CreatorId == creatorId).ToList();
        
    }

    public bool DeleteHike(Guid id)
    {
        _context.Hikes.Where(h => h.Id == id).ExecuteDelete();
        _context.SaveChanges();
        return true;
    }

    public Guid AddHike(Hike hike)
    {
        hike.Id = Guid.NewGuid();
        _context.Hikes.Add(hike);
        _context.SaveChanges();
        return hike.Id;
    }

    public bool UpdateHike(Hike hike)
    {
        var existingHike = _context.Hikes.FirstOrDefault(r => r.Id == hike.Id);
        if (existingHike != null)
        {
            _context.Entry(existingHike).State = EntityState.Detached;
        }

        _context.Hikes.Attach(hike);
        _context.Entry(hike).State = EntityState.Modified;

        _context.SaveChanges();
        return true;
    }

    public bool HikeExists(Guid id)
    {
        return _context.Hikes.Any(h => h.Id == id);
    }
}