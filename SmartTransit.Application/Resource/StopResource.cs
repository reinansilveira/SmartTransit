namespace SmartTransit.Application.Resource;

public class StopResource
{
    public long? Id { get; set; }
    public required string Name { get; set; }

    public required double Latitude { get; set; }
    
    public required double Longitude { get; set; }
}