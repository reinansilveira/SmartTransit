namespace SmartTransit.Domain.Domains.DTO.VehiclePositionDTO;

public class VehiclePositionDTO
{
    public required double VehiclePosition { get; set; }
    
    public required double Longitude { get; set; }
    
    public required long VehicleId { get; set; }
}