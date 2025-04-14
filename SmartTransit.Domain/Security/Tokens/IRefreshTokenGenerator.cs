namespace SmartTransit.Domain.Security.Tokens;

public interface IRefreshTokenGenerator
{
    public string Generate(Guid useridentifier);
}