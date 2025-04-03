using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmartTransit.Application.Mappings;
using SmartTransit.Domain.Gateway.Line;
using SmartTransit.Domain.Gateway.Stop;
using SmartTransit.Domain.Gateway.Vehicle;
using SmartTransit.Domain.Gateway.VehiclePosition;
using SmartTransit.Domain.Services;
using SmartTransit.Domain.UseCases;
using SmartTransit.Domain.UseCases.Stop;
using SmartTransit.Domain.UseCases.Vehicle;
using SmartTransit.Domain.UseCases.VehiclePosition;
using SmartTransit.Infrastructure.Persistence;
using SmartTransit.Infrastructure.Repositories;

namespace SmartTransit.Application.DependencyInjection;

public static class DependencyInjection
{
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services,
            IConfiguration configuration)
        {
            var mySqlConnectionString = configuration.GetConnectionString("MySQLConnection");
       

            if (string.IsNullOrEmpty(mySqlConnectionString))
            {
                throw new ArgumentException("MySql connectionString or databaseName not configured.");
            }
        
            services.AddDbContext<SmartTransitDbContext>(options =>
                options.UseMySql(mySqlConnectionString, ServerVersion.AutoDetect(mySqlConnectionString)));

            services.AddControllers();

            services.AddAutoMapper(
                typeof(ResourceToDtoProfileLine),
                typeof(ResourceToDtoProfileStop),
                typeof(ResourceToDtoProfileVehicle)
            );

            services.AddScoped<ILineCrudUseCases,LineCrudUseService>();
            services.AddScoped<ILineRepositoryGateway, LineRepository>();
        
            services.AddScoped<IStopCrudUseCases,StopCrudUseService>();
            services.AddScoped<IStopRepositoryGateway, StopRepository>();
        
            services.AddScoped<IVehicleCrudUseCases,VehicleCrudUseService>();
            services.AddScoped<IVehicleRepositoryGateway, VehicleRepository>();
        
            services.AddScoped<IVehiclePositionCrudUseCases,VehiclePositionCrudUseService>();
            services.AddScoped<IVehiclePositionRepositoryGateway, VehiclePositionRepository>();

            return services;
        }
    }
