using HikingInformationSystemDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HikingInformationSystemInfrastructure.Data.Configuration;

public class PointConfiguration : IEntityTypeConfiguration<Point>
{
    public void Configure(EntityTypeBuilder<Point> builder)
    {
        builder
            .HasOne(p => p.Route)
            .WithMany(r => r.Points)
            .HasForeignKey(p => p.RouteId); 
    }
}