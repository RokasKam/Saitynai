using HikingInformationSystemDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HikingInformationSystemInfrastructure.Data.Configuration;

public class HikeConfiguration : IEntityTypeConfiguration<Hike>
{
    public void Configure(EntityTypeBuilder<Hike> builder) { }
}