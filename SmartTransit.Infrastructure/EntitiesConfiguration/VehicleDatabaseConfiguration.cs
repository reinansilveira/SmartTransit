using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartTransit.Infrastructure.Entities;
using SmartTransit.Infrastructure.Entities.Vehicle;

namespace SmartTransit.Infrastructure.EntitiesConfiguration;

public class VehicleDatabaseConfiguration: IEntityTypeConfiguration<VehicleEntity> 
{
    public void Configure(EntityTypeBuilder<VehicleEntity> builder)
    {
        builder.ToTable("vehicles");
        builder.HasKey(l => l.Id);
    }
    
} 