namespace SmartTransit.Infrastructure.Entities;

public class LineEntity
{
    public long Id { get; set; }
    
    public required string Name { get; set; }
    
    public required ICollection <StopEntity> Stops { get; set; }
}