using AutoMapper;
using SmartTransit.Application.Resource;
using SmartTransit.Application.Resource.Stop;
using SmartTransit.Domain.Domains.DTO;
using SmartTransit.Infrastructure.Entities;
using SmartTransit.Infrastructure.Entities.Stop;

namespace SmartTransit.Application.Mappings;

public class ResourceToDtoProfileStop : Profile
{
    public ResourceToDtoProfileStop()
    {
        CreateMap<StopResource, StopDTO>().ReverseMap(); 
        CreateMap<StopEntity, StopDTO>().ReverseMap(); 
        CreateMap<StopEntity, StopResource>().ReverseMap();
      
    }
}