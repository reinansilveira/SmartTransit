namespace SmartTransit.Domain.Domains.DTO;

public class LoginResponseDTO
{
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
}