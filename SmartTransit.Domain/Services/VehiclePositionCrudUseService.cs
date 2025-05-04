using SmartTransit.Domain.Domains.DTO;
using SmartTransit.Domain.Domains.DTO.VehiclePositionDTO;
using SmartTransit.Domain.Domains.Exceptions;
using SmartTransit.Domain.Gateway.Vehicle;
using SmartTransit.Domain.Gateway.VehiclePosition;
using SmartTransit.Domain.UseCases.VehiclePosition;

namespace SmartTransit.Domain.Services;

public class VehiclePositionCrudUseService : IVehiclePositionCrudUseCases
{
    private readonly IVehiclePositionRepositoryGateway _vehiclePositionRepositoryGateway;
    private readonly IVehicleRepositoryGateway _vehicleRepositoryGateway;

    public VehiclePositionCrudUseService(IVehiclePositionRepositoryGateway vehiclePositionRepositoryGateway, IVehicleRepositoryGateway vehicleRepositoryGateway)
    {
        _vehiclePositionRepositoryGateway = vehiclePositionRepositoryGateway;
        _vehicleRepositoryGateway = vehicleRepositoryGateway;
    }
    
    public async Task<VehiclePositionDTO?> Create(VehiclePositionDTO vehicle)
    {
        var vehicleId = _vehicleRepositoryGateway.GetById(vehicle.VehicleId);
        if (vehicleId == null)
        {
            throw new VehicleDoesNotExistException(404, $"Vehicle with ID {vehicleId} not found.");
        }
        return await _vehiclePositionRepositoryGateway.Create(vehicle);
    }

    public async Task<VehiclePositionDTO?> Update(VehiclePositionDTO vehicle, long vehicleId)
    {
        await EnsureLineExists(vehicleId);
        return await _vehiclePositionRepositoryGateway.Update(vehicle, vehicleId);
    }

    public async Task<VehiclePositionDTO?> Delete(long vehicleId)
    {
        await EnsureLineExists(vehicleId);
        return await _vehiclePositionRepositoryGateway.Delete(vehicleId);
    }

    public async Task<VehiclePositionDTO?> GetById(long vehicleId)
    {
        await EnsureLineExists(vehicleId);
        return await _vehiclePositionRepositoryGateway.GetById(vehicleId);
    }
    
    private async Task<VehicleDTO> EnsureLineExists(long vehicleId)
    {
        var vehicle = await _vehicleRepositoryGateway.GetById(vehicleId);
        if (vehicle == null)
        {
            throw new VehicleDoesNotExistException(404, $"Line with ID {vehicle} does not exist.");
        }

        return vehicle;
    }
}