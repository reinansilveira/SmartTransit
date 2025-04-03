using SmartTransit.Domain.Domains.DTO;

namespace SmartTransit.Domain.Gateway.Vehicle;

public interface IVehicleRepositoryGateway
{
    Task<VehicleDTO?> Create(VehicleDTO vehicle);

    Task<VehicleDTO?> Update(VehicleDTO vehicle, long vehicleId);

    Task<VehicleDTO?> Delete(long vehicleId);
    Task<ICollection<VehicleDTO>> GetVehiclesByLineId(long linesId);

    Task<VehicleDTO?> GetById(long vehicleId);
}