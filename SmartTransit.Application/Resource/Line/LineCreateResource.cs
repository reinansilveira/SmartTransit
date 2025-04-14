namespace SmartTransit.Application.Resource.Line;

public class LineCreateResource
{
    public required string Name { get; set; }
    
    public required List<long> Stops { get; set; }
}