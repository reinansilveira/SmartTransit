using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartTransit.Infrastructure.Entities;

namespace SmartTransit.Infrastructure.EntitiesConfiguration;

public class LineDatabaseConfiguration: IEntityTypeConfiguration<LineEntity>
{
    public void Configure(EntityTypeBuilder<LineEntity> builder)
    {
        builder.ToTable("lines");
        builder.HasKey(l => l.Id);
    }
}