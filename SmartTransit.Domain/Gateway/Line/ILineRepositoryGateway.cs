using SmartTransit.Domain.Domains.DTO;

namespace SmartTransit.Domain.Gateway.Line;

public interface ILineRepositoryGateway
{
    Task<LineResponseDTO> Create(LineCreateDTO line);

    Task<LineDTO?> AddStop(LineCreateDTO line, long lineId);

    Task<LineDTO?> RemoveStop(LineCreateDTO line, long lineId);

    Task<LineDTO?> Update(LineCreateDTO line, long lineId);

    Task<LineDTO?> Delete(long lineId);

    Task<ICollection<LineResponseDTO>> GetLinesByStopId(long stopId);

    Task<LineDTO?> GetById(long lineId);
}