using SmartTransit.Domain.Domains.DTO;
using SmartTransit.Domain.Gateway.VehiclePosition;
using SmartTransit.Domain.UseCases.VehiclePosition;

namespace SmartTransit.Domain.Services;

public class VehiclePositionCrudUseService : IVehiclePositionCrudUseCases
{
    private readonly IVehiclePositionRepositoryGateway _vehiclePositionRepositoryGateway;

    public VehiclePositionCrudUseService(IVehiclePositionRepositoryGateway vehiclePositionRepositoryGateway)
    {
        _vehiclePositionRepositoryGateway = vehiclePositionRepositoryGateway;
    }
    
    public async Task<VehiclePositionDTO?> Create(VehiclePositionDTO vehicle)
    {
        return await _vehiclePositionRepositoryGateway.Create(vehicle);
    }

    public async Task<VehiclePositionDTO?> Update(VehiclePositionDTO vehicle, long vehicleId)
    {
        return await _vehiclePositionRepositoryGateway.Update(vehicle, vehicleId);
    }

    public async Task<VehiclePositionDTO?> Delete(long vehicleId)
    {
        return await _vehiclePositionRepositoryGateway.Delete(vehicleId);
    }

    public async Task<VehiclePositionDTO?> GetById(long vehicleId)
    {
        return await _vehiclePositionRepositoryGateway.GetById(vehicleId);
    }
}