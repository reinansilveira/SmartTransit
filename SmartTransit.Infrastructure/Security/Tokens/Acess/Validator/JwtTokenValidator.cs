using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace SmartTransit.Infrastructure.Security.Tokens.Acess.Validator;

public partial class JwtTokenValidator : JwtTokenHandler, IAccessTokenValidator
{
    private readonly string _signingKey;
    private readonly string _issuer;
    private readonly string _audience;

    public JwtTokenValidator(IConfiguration config)
    {
        _signingKey = config["Settings:Jwt:SigningKey"];  // Carrega a chave de assinatura
        _issuer = config["Settings:Jwt:Issuer"];         // Carrega o Issuer
        _audience = config["Settings:Jwt:Audience"];     // Carrega o Audience
    }

    public Guid ValidateAndGetUserIdentifier(string token)
    {
        var principal = GetPrincipalFromToken(token);
        var userId = principal.Claims.First(c => c.Type == "id").Value;
        return Guid.Parse(userId);
    }

    public ClaimsPrincipal GetPrincipalFromToken(string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var validationParameter = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidIssuer = _issuer,                          // Usando a mesma configuração de Issuer
            ValidAudience = _audience,                      // Usando a mesma configuração de Audience
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_signingKey)), // Usando a chave de assinatura
            ClockSkew = TimeSpan.Zero
        };

        return tokenHandler.ValidateToken(token, validationParameter, out _);  // Valida o token com a chave de assinatura
    }
}