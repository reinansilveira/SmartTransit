namespace SmartTransit.Domain.Domains.DTO;

public class VehiclePositionDTO
{
    public required double VehiclePosition { get; set; }
    
    public required double Longitude { get; set; }
    
    public required long VehicleId { get; set; }
}