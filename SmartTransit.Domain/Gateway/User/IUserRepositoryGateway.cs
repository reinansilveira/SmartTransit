using SmartTransit.Domain.Domains.DTO;

namespace SmartTransit.Domain.Gateway.User;

public interface IUserRepositoryGateway
{
    Task<UserDTO> RegisterUser(UserDTO user);
    
    Task<UserDTO?> GetByEmail(string email);
    
    Task<UserDTO?> GetById(Guid userId);
    
}