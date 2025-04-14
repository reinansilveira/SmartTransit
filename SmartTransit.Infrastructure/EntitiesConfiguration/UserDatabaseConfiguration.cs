using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartTransit.Infrastructure.Entities;

namespace SmartTransit.Infrastructure.EntitiesConfiguration;

public class UserDatabaseConfiguration : IEntityTypeConfiguration<UserEntity> 
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder.ToTable("users");
        builder.HasKey(l => l.Id);
    }

    
} 