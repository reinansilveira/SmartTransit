using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartTransit.Infrastructure.Entities;
using SmartTransit.Infrastructure.Entities.VehiclePosition;

namespace SmartTransit.Infrastructure.EntitiesConfiguration;

public class VehiclePositionDatabase : IEntityTypeConfiguration<VehiclePositionEntity>
{
    public void Configure(EntityTypeBuilder<VehiclePositionEntity> builder)
    {
        builder.ToTable("vehicle_positions")
            .HasNoKey(); 
    }
}