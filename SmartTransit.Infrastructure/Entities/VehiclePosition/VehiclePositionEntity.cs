namespace SmartTransit.Infrastructure.Entities;

public class VehiclePositionEntity
{
    public required double VehiclePosition { get; set; }
    
    public required double Longitude { get; set; }
    
    public required long VehicleId { get; set; }
}