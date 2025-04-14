using SmartTransit.Application.Resource.Stop;

namespace SmartTransit.Application.Resource.Line;

public class LineResponseResource
{
    public long? Id { get; set; }
    
    public required string Name { get; set; }
    
    public required ICollection<StopResource> Stops { get; set; }
}