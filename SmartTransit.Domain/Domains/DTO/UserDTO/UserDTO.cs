namespace SmartTransit.Domain.Domains.DTO;

public class UserDTO
{
    public Guid Id { get; set; }

    public string Name { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }

    public string UserIdentifier { get; set; }
}