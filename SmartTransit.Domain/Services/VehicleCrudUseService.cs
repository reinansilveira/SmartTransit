using SmartTransit.Domain.Domains.DTO;
using SmartTransit.Domain.Gateway.Vehicle;
using SmartTransit.Domain.UseCases.Vehicle;

namespace SmartTransit.Domain.Services;

public class VehicleCrudUseService : IVehicleCrudUseCases
{
    private readonly IVehicleRepositoryGateway _vehicleRepositoryGateway;

    public VehicleCrudUseService(IVehicleRepositoryGateway vehicleRepositoryGateway)
    {
        _vehicleRepositoryGateway = vehicleRepositoryGateway;
    }

    public async Task<VehicleDTO> Create(VehicleDTO vehicle)
    {
        return await _vehicleRepositoryGateway.Create(vehicle);
    }

    public async Task<VehicleDTO?> Update(VehicleDTO vehicle, long vehicleId)
    {
        return await _vehicleRepositoryGateway.Update(vehicle, vehicleId);
    }

    public async Task<VehicleDTO?> Delete(long vehicleId)
    {
        return await _vehicleRepositoryGateway.Delete(vehicleId);
    }

    public async Task<ICollection<VehicleDTO>> GetVehiclesByLineId(long linesId)
    {
        return await _vehicleRepositoryGateway.GetVehiclesByLineId(linesId);
    }

    public async Task<VehicleDTO?> GetById(long vehicleId)
    {
        return await _vehicleRepositoryGateway.GetById(vehicleId);
    }
}