namespace SmartTransit.Domain.Domains.DTO;

public class VehicleDTO
{
    public long? Id { get; set; }

    public required string Name { get; set; }
    
    public required string Modelo { get; set; }
    
    public required long LineId { get; set; }
}