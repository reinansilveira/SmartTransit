using SmartTransit.Domain.Domains.DTO;
using SmartTransit.Domain.Domains.DTO.VehiclePositionDTO;

namespace SmartTransit.Domain.UseCases.VehiclePosition;

public interface IVehiclePositionCrudUseCases
{
    Task<VehiclePositionDTO?> Create(VehiclePositionDTO vehicle);

    Task<VehiclePositionDTO?> Update(VehiclePositionDTO vehicle, long vehicleId);

    Task<VehiclePositionDTO?> Delete(long vehicleId);

    Task<VehiclePositionDTO?> GetById(long vehicleId);
}