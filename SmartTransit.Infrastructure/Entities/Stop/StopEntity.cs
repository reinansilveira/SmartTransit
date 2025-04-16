namespace SmartTransit.Infrastructure.Entities.Stop;

public class StopEntity
{
    public long Id { get; set; }

    public string Name { get; set; }

    public double Latitude { get; set; }
    
    public double Longitude { get; set; }
}