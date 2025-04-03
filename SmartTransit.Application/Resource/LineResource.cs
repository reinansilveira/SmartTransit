namespace SmartTransit.Application.Resource;

public class LineResource
{
    public long? Id { get; set; }
    
    public required string Name { get; set; }

    public required List<long> Stops { get; set; } 
}