using HikingInformationSystemDomain.Entities;
using HikingInformationSystemInfrastructure.Data.Configuration;
using Microsoft.EntityFrameworkCore;

namespace HikingInformationSystemInfrastructure.Data;

public class HikingInformationSystemDataContext : DbContext
{
    public DbSet<Hike> Hikes { get; set; }
    public DbSet<Route> Routes { get; set; }
    public DbSet<Point> Points { get; set; }
    
    public HikingInformationSystemDataContext(DbContextOptions<HikingInformationSystemDataContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(HikeConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(RouteConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PointConfiguration).Assembly);
    }
}