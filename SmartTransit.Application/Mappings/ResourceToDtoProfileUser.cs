using AutoMapper;
using SmartTransit.Application.Resource;
using SmartTransit.Application.Resource.Login;
using SmartTransit.Application.Resource.User;
using SmartTransit.Domain.Domains.DTO;
using SmartTransit.Infrastructure.Entities;

namespace SmartTransit.Application.Mappings;

public class ResourceToDtoProfileUser : Profile
{
    public ResourceToDtoProfileUser()
    {
        CreateMap<UserResource, UserDTO>().ReverseMap();
        CreateMap<UserEntity, UserDTO>().ReverseMap();
        CreateMap<UserDTO, UserResponseResource>().ReverseMap();
        CreateMap<LoginResource, LoginDTO>().ReverseMap();
    }
}