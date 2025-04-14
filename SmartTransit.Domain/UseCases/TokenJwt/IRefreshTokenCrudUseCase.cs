using SmartTransit.Domain.Domains.DTO;

namespace SmartTransit.Domain.UseCases;

public interface IRefreshTokenCrudUseCase
{
    Task<LoginResponseDTO> Execute(string refreshToken);
}