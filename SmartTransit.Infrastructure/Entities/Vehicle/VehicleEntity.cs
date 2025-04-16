namespace SmartTransit.Infrastructure.Entities.Vehicle;

public class VehicleEntity
{
    public required long Id { get; set; }

    public required string Name { get; set; }
    
    public required string Modelo { get; set; }
    
    public required long LineId { get; set; }
}