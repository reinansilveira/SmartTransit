using AutoMapper;
using SmartTransit.Application.Resource;
using SmartTransit.Application.Resource.Vehicle;
using SmartTransit.Domain.Domains.DTO;
using SmartTransit.Infrastructure.Entities;
using SmartTransit.Infrastructure.Entities.Vehicle;

namespace SmartTransit.Application.Mappings;

public class ResourceToDtoProfileVehicle : Profile
{
    public ResourceToDtoProfileVehicle()
    {
        CreateMap<VehicleResource, VehicleDTO>().ReverseMap();

        CreateMap<VehicleDTO, VehicleEntity>().ReverseMap();

        CreateMap<VehicleEntity, VehicleDTO>().ReverseMap();

        CreateMap<VehicleDTO, VehicleResource>().ReverseMap();
    }
}