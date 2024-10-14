using HikingInformationSystemDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HikingInformationSystemInfrastructure.Data.Configuration;

public class RouteConfiguration : IEntityTypeConfiguration<Route>
{
    public void Configure(EntityTypeBuilder<Route> builder)
    {
        builder
            .HasOne(r => r.Hike)
            .WithMany(h => h.Routes)
            .HasForeignKey(r => r.HikeId); 
    }
}