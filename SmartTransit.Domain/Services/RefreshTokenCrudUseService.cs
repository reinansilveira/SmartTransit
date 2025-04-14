using System.Globalization;
using SmartTransit.Domain.Domains.DTO;
using SmartTransit.Domain.Gateway.User;
using SmartTransit.Domain.UseCases;

namespace SmartTransit.Domain.Services;

public class RefreshTokenCrudUseService : IRefreshTokenCrudUseCase
{
    private readonly IJwtCrudUseCase _jwtCrudUseCase;
    private readonly IUserRepositoryGateway _userRepository;

    public RefreshTokenCrudUseService(IJwtCrudUseCase jwtCrudUseCase, IUserRepositoryGateway userRepository)
    {
        _jwtCrudUseCase = jwtCrudUseCase;
        _userRepository = userRepository;
    }

    public async Task<LoginResponseDTO> Execute(string refreshToken)
    {
        var userId = _jwtCrudUseCase.ValidateRefreshToken(refreshToken);
        if (!userId.HasValue)
        {
            throw new InvalidOperationException("Invalid refresh token.");
        }

        var user = await _userRepository.GetById(userId.Value);
        if (user == null)
        {
            throw new KeyNotFoundException("User not found.");
        }
        
        return _jwtCrudUseCase.GenerateTokens(user);
    }
}