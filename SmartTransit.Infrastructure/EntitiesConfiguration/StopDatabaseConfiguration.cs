using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartTransit.Infrastructure.Entities;

namespace SmartTransit.Infrastructure.EntitiesConfiguration;

public class StopDatabaseConfiguration: IEntityTypeConfiguration<StopEntity> 
{
    public void Configure(EntityTypeBuilder<StopEntity> builder)
    {
        builder.ToTable("stops");
        builder.HasKey(l => l.Id);
    }
    
} 
