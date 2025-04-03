namespace SmartTransit.Application.Resource;

public class LineResponseResource
{
    public long? Id { get; set; }
    
    public required string Name { get; set; }
    
    public required ICollection<StopResource> Stops { get; set; }
}