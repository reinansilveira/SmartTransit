namespace SmartTransit.Domain.Domains.DTO;

public class LineDTO
{
    public long? Id { get; set; }
    
    public required string Name { get; set; }
    
    public required ICollection<StopDTO> Stops { get; set; }
}