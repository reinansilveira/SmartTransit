namespace SmartTransit.Application.Resource.Vehicle;

public class VehicleCreateResource
{
    public required string Name { get; set; }
    
    public required string Modelo { get; set; }
    
    public required long LineId { get; set; }
}