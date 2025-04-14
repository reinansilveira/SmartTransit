namespace SmartTransit.Application.Resource.User;

public class UserResponseResource
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string Name { get; set; }
    public string UserIdentifier { get; set; }
}