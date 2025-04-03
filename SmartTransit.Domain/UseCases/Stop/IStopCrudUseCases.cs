using SmartTransit.Domain.Domains.DTO;

namespace SmartTransit.Domain.UseCases.Stop;

public interface IStopCrudUseCases
{
    Task<StopDTO> Create(StopDTO stop);
    
    Task<StopDTO> Update(StopDTO stop, long stopId);

    Task<StopDTO> Delete(long stopId);

    Task<StopDTO> GetById(long stopId);
}