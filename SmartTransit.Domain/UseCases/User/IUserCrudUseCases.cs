using SmartTransit.Domain.Domains.DTO;

namespace SmartTransit.Domain.UseCases.User;

public interface IUserCrudUseCases
{
    Task<UserDTO> RegisterUser(UserDTO stop);

    Task<UserDTO?> GetById(Guid userId);
}