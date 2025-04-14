using SmartTransit.Domain.Domains.DTO;
using SmartTransit.Domain.Gateway.Line;
using SmartTransit.Domain.Gateway.User;
using SmartTransit.Domain.Security.Criptography;
using SmartTransit.Domain.UseCases.User;

namespace SmartTransit.Domain.Services;

public class UserCrudUseService : IUserCrudUseCases
{
    private readonly IUserRepositoryGateway _repositoryGateway;
    private readonly IPasswordEncripter _passwordEncripter;

    public UserCrudUseService(IUserRepositoryGateway repositoryGateway, IPasswordEncripter passwordEncripter)
    {
        _repositoryGateway = repositoryGateway;
        _passwordEncripter = passwordEncripter;
    }

    public async Task<UserDTO> RegisterUser(UserDTO userDto)
    {
        var user = new UserDTO
        {
            Name = userDto.Name,
            Email = userDto.Email,
            PasswordHash = _passwordEncripter.Encrypt(userDto.PasswordHash)
        };

        return await _repositoryGateway.RegisterUser(user);
    }


    public Task<UserDTO?> GetById(Guid userId)
    {
        return _repositoryGateway.GetById(userId);
    }
}