namespace SmartTransit.Application.Resource;

public class VehicleResource
{
    public long? Id { get; set; }

    public required string Name { get; set; }
    
    public required string Modelo { get; set; }
    
    public required long LineId { get; set; }
}