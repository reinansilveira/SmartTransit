using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SmartTransit.Domain.Domains.DTO;
using SmartTransit.Domain.UseCases;

namespace SmartTransit.Infrastructure.Security.Tokens.Acess.Generator;

public class JwtService : IJwtCrudUseCase
{
    private readonly string? _signingKey;  
    private readonly int _expirationTimeMinutes;  
    private readonly string? _issuer;
    private readonly string? _audience;

    public JwtService(IConfiguration config)
    {
        _signingKey = config["Settings:Jwt:SigningKey"];  
        _issuer = config["Settings:Jwt:Issuer"];
        _audience = config["Settings:Jwt:Audience"];
        _expirationTimeMinutes = int.TryParse(config["Settings:Jwt:ExpirationTimeMinutes"], out var value) ? value : 15;

        if (string.IsNullOrEmpty(_signingKey))
        {
            throw new Exception("JWT SigningKey is missing or invalid in configuration.");
        }
    }

    public LoginResponseDTO GenerateTokens(UserDTO user)
    {
        var accessToken = GenerateToken(user, _signingKey, _expirationTimeMinutes);
        var refreshToken = GenerateToken(user, _signingKey, 60 * 24 * 7); 

        return new LoginResponseDTO { AccessToken = accessToken, RefreshToken = refreshToken };
    }

    private string GenerateToken(UserDTO user, string? secret, int minutes)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _issuer,
            audience: _audience,
            claims: new[] { new Claim("id", user.Id.ToString()) },
            expires: DateTime.UtcNow.AddMinutes(minutes),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public Guid? ValidateAccessToken(string token) => ValidateToken(token, _signingKey);

    public Guid? ValidateRefreshToken(string token) => ValidateToken(token, _signingKey);

    private Guid? ValidateToken(string token, string? secret)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes(secret);

        try
        {
            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidIssuer = _issuer,
                ValidAudience = _audience,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            }, out SecurityToken validatedToken);

            var jwtToken = (JwtSecurityToken)validatedToken;
            var userId = jwtToken.Claims.First(x => x.Type == "id").Value;
            return Guid.Parse(userId);
        }
        catch (SecurityTokenExpiredException ex)
        {
            Console.WriteLine($"Token expired: {ex.Message}");
            return null;
        }
        catch (SecurityTokenException ex)
        {
            throw new Exception($"Invalid token: {ex.Message}");
        }
        catch (Exception ex)
        {
            throw new Exception($"Token validation error: {ex.Message}");
        }
    }
}
