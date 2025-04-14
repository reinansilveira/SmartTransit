using SmartTransit.Domain.Domains.DTO;

namespace SmartTransit.Domain.UseCases.Login;

public interface ILoginCrudUseCase
{
    Task<LoginResponseDTO> LoginUser(LoginDTO loginDto);
}