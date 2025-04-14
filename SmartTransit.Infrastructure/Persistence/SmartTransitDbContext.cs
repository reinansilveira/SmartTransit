using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using SmartTransit.Infrastructure.Entities;

namespace SmartTransit.Infrastructure.Persistence;

public class SmartTransitDbContext : DbContext
{
        public SmartTransitDbContext(DbContextOptions<SmartTransitDbContext> options) : base(options)
        {
        }

        public DbSet<UserEntity> UserEntities { get; set; }
        public DbSet<LineEntity> LineEntities { get; set; }
        public DbSet<StopEntity> StopEntities { get; set; }
        public DbSet<VehicleEntity> VehicleEntities { get; set; }
        public DbSet<VehiclePositionEntity> VehiclePositionEntities { get; set; }

        public SmartTransitDbContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<VehiclePositionEntity>()
                .HasKey(vp => vp.VehicleId);

            modelBuilder.Entity<VehicleEntity>()
                .HasOne<LineEntity>()
                .WithMany()
                .HasForeignKey(v => v.LineId);

            modelBuilder.Entity<LineEntity>()
                .Property(l => l.Stops)
                .HasConversion(
                    stops => JsonSerializer.Serialize(stops, (JsonSerializerOptions?)null),
                    stopsJson => JsonSerializer.Deserialize<List<StopEntity>>(stopsJson!, (JsonSerializerOptions?)null) ??
                                 new List<StopEntity>() 
                )
                .HasColumnName("StopsJson") 
                .IsRequired();
        }
    }
