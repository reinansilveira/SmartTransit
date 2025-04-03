using SmartTransit.Domain.Domains.DTO;

namespace SmartTransit.Domain.UseCases.VehiclePosition;

public interface IVehiclePositionCrudUseCases
{
    Task<VehiclePositionDTO?> Create(VehiclePositionDTO vehicle);

    Task<VehiclePositionDTO?> Update(VehiclePositionDTO vehicle, long vehicleId);

    Task<VehiclePositionDTO?> Delete(long vehicleId);

    Task<VehiclePositionDTO?> GetById(long vehicleId);
}