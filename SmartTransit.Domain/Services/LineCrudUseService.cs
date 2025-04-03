using SmartTransit.Domain.Domains.DTO;
using SmartTransit.Domain.Gateway.Line;
using SmartTransit.Domain.UseCases;

namespace SmartTransit.Domain.Services;

public class LineCrudUseService : ILineCrudUseCases
{
    private readonly ILineRepositoryGateway _lineRepositoryGateway;

    public LineCrudUseService(ILineRepositoryGateway lineRepositoryGateway)
    {
        _lineRepositoryGateway = lineRepositoryGateway;
    }
    public Task<LineResponseDTO> Create(LineCreateDTO line)
    {
        return _lineRepositoryGateway.Create(line);
    }

    public Task<LineDTO> Update(LineCreateDTO line, long lineId)
    {
       return _lineRepositoryGateway.Update(line, lineId);
    }

    public Task<LineDTO> Delete(long lineId)
    {
        return _lineRepositoryGateway.Delete(lineId);
    }

    public Task<ICollection<LineResponseDTO>> GetLinesByStopId(long stopId)
    {
        return _lineRepositoryGateway.GetLinesByStopId(stopId);
    }

    public Task<LineDTO> GetById(long lineId)
    {
        return _lineRepositoryGateway.GetById(lineId);
    }
}