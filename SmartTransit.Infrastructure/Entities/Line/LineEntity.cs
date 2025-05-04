using SmartTransit.Infrastructure.Entities.Stop;

namespace SmartTransit.Infrastructure.Entities.Line;

public class LineEntity
{
    public long Id { get; set; }
    
    public required string Name { get; set; }
    
    public required ICollection <StopEntity> Stops { get; set; }
}