using SmartTransit.Domain.Domains.DTO;
using SmartTransit.Domain.Domains.DTO.VehiclePositionDTO;

namespace SmartTransit.Domain.Gateway.VehiclePosition;

public interface IVehiclePositionRepositoryGateway
{
    Task<VehiclePositionDTO?> Create(VehiclePositionDTO vehicle);

    Task<VehiclePositionDTO?> Update(VehiclePositionDTO vehicle, long vehicleId);

    Task<VehiclePositionDTO?> Delete(long vehicleId);

    Task<VehiclePositionDTO?> GetById(long vehicleId);
}