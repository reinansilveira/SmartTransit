namespace SmartTransit.Domain.Domains.DTO;

public class LineCreateDTO
{
    public required string Name { get; set; }

    public required List<long> Stops { get; set; }
}