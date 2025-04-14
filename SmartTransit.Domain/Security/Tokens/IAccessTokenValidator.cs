using System.Security.Claims;

public interface IAccessTokenValidator
{
    Guid ValidateAndGetUserIdentifier(string token);
    ClaimsPrincipal GetPrincipalFromToken(string token);
}