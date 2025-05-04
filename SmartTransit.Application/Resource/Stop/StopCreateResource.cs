namespace SmartTransit.Application.Resource.Stop;

public class StopCreateResource
{
    public required string Name { get; set; }

    public required double Latitude { get; set; }
    
    public required double Longitude { get; set; }
}