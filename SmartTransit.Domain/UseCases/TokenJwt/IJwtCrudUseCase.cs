using SmartTransit.Domain.Domains.DTO;

namespace SmartTransit.Domain.UseCases;

public interface IJwtCrudUseCase
{
    
    LoginResponseDTO GenerateTokens(UserDTO user);
    Guid? ValidateAccessToken(string token);
    Guid? ValidateRefreshToken(string token);
}