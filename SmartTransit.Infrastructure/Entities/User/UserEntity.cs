namespace SmartTransit.Infrastructure.Entities;

public class UserEntity
{
    public Guid Id { get; set; }  
    public string Name { get; set; }  
    public string Email { get; set; }  
    public string PasswordHash { get; set; }  
    public Guid UserIdentifier { get; set; }
}