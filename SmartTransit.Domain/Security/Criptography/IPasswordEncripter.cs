namespace SmartTransit.Domain.Security.Criptography;

public interface IPasswordEncripter
{
    public string Encrypt(string password);
    
    bool IsValid(string password, string passwordHash);
}