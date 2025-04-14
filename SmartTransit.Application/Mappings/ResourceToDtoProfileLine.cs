using AutoMapper;
using SmartTransit.Application.Resource;
using SmartTransit.Application.Resource.Line;
using SmartTransit.Domain.Domains.DTO;
using SmartTransit.Infrastructure.Entities;

namespace SmartTransit.Application.Mappings;

public class ResourceToDtoProfileLine : Profile
{
    public ResourceToDtoProfileLine()
    {
        CreateMap<LineCreateResource, LineCreateDTO>().ReverseMap();

        
        CreateMap<LineCreateDTO, LineEntity>()
            .ForMember(dest => dest.Stops, opt => opt.MapFrom(src => src.Stops.Select(id => new StopEntity { Id = id }))); // Converte IDs para StopEntity
        
        CreateMap<LineEntity, LineResponseResource>().ReverseMap();
        
        CreateMap<LineEntity, LineResponseDTO>();
        CreateMap<LineEntity, LineResponseResource>().ReverseMap();

        CreateMap<LineEntity, LineDTO>().ReverseMap();
        CreateMap<LineResponseDTO, LineResponseResource>().ReverseMap();

    }
}