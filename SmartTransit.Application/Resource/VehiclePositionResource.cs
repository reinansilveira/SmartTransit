namespace SmartTransit.Application.Resource;

public class VehiclePositionResource
{
    public required double VehiclePosition { get; set; }
    
    public required double Longitude { get; set; }
    
    public required long VehicleId { get; set; }
}