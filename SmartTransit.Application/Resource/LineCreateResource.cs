namespace SmartTransit.Application.Resource;

public class LineCreateResource
{
    public required string Name { get; set; }
    
    public required List<long> Stops { get; set; }
}