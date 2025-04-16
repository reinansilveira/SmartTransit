using SmartTransit.Domain.Domains.DTO;
using SmartTransit.Domain.Domains.Exceptions;
using SmartTransit.Domain.Gateway.Stop;
using SmartTransit.Domain.UseCases.Stop;

namespace SmartTransit.Domain.Services;

public class StopCrudUseService : IStopCrudUseCases
{
    private readonly IStopRepositoryGateway _stopRepositoryGateway;

    public StopCrudUseService(IStopRepositoryGateway stopRepositoryGateway)
    {
        _stopRepositoryGateway = stopRepositoryGateway;
    }
    
    public async Task<StopDTO> Create(StopDTO stop)
    {
        return await _stopRepositoryGateway.Create(stop);
    }

    public async Task<StopDTO> Update(StopDTO stop, long stopId)
    {
        await EnsureStopExists(stopId);
        return await _stopRepositoryGateway.Update(stop, stopId);
    }

    public async Task<StopDTO> Delete(long stopId)
    {
        await EnsureStopExists(stopId);
        return await _stopRepositoryGateway.Delete(stopId);
    }

    public async Task<StopDTO> GetById(long stopId)
    {
        return await EnsureStopExists(stopId);
    }
    
    private async Task<StopDTO> EnsureStopExists(long stopId)
    {
        var stop = await _stopRepositoryGateway.GetById(stopId);
        if (stop == null)
        {
            throw new StopDoesNotExistException(404, $"Stop with ID {stopId} does not exist.");
        }

        return stop;
    }
}