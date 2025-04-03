using SmartTransit.Domain.Domains.DTO;

namespace SmartTransit.Domain.UseCases.Vehicle;

public interface IVehicleCrudUseCases
{
    Task<VehicleDTO?> Create(VehicleDTO vehicle);

    Task<VehicleDTO?> Update(VehicleDTO vehicle, long vehicleId);

    Task<VehicleDTO?> Delete(long vehicleId);

    Task<ICollection<VehicleDTO>> GetVehiclesByLineId (long linesId);

    Task<VehicleDTO?> GetById(long vehicleId);
}