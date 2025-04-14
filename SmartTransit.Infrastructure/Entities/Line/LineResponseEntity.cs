namespace SmartTransit.Infrastructure.Entities;

public class LineResponseEntity
{
    public long Id { get; set; }
    
    public required string Name { get; set; }
    
    public required List<StopEntity> Paradas { get; set; }
}