using SmartTransit.Domain.Domains.DTO;
using SmartTransit.Domain.Domains.Exceptions;
using SmartTransit.Domain.Gateway.Line;
using SmartTransit.Domain.Gateway.Vehicle;
using SmartTransit.Domain.UseCases.Vehicle;

namespace SmartTransit.Domain.Services;

public class VehicleCrudUseService : IVehicleCrudUseCases
{
    private readonly IVehicleRepositoryGateway _vehicleRepositoryGateway;
    private readonly ILineRepositoryGateway _lineRepositoryGateway;

    public VehicleCrudUseService(IVehicleRepositoryGateway vehicleRepositoryGateway, ILineRepositoryGateway lineRepositoryGateway)
    {
        _vehicleRepositoryGateway = vehicleRepositoryGateway;
        _lineRepositoryGateway = lineRepositoryGateway;
    }

    public async Task<VehicleDTO> Create(VehicleDTO vehicle)
    {
        return await _vehicleRepositoryGateway.Create(vehicle);
    }

    public async Task<VehicleDTO?> Update(VehicleDTO vehicle, long vehicleId)
    {
        await EnsureVehicleExists(vehicleId);
        return await _vehicleRepositoryGateway.Update(vehicle, vehicleId);
    }

    public async Task<VehicleDTO?> Delete(long vehicleId)
    {
        await EnsureVehicleExists(vehicleId);
        return await _vehicleRepositoryGateway.Delete(vehicleId);
    }

    public async Task<ICollection<VehicleDTO>> GetVehiclesByLineId(long lineId)
    {
        var line = _lineRepositoryGateway.GetById(lineId);
        if (line == null)
        {
            throw new LineDoesNotExisException(404, $"Line with ID {lineId} not found.");
        }
        return await _vehicleRepositoryGateway.GetVehiclesByLineId(lineId);
    }

    public async Task<VehicleDTO?> GetById(long vehicleId)
    {
        return await EnsureVehicleExists(vehicleId);
    }
    
    private async Task<VehicleDTO> EnsureVehicleExists(long vehicleId)
    {
        var vehicle = await _vehicleRepositoryGateway.GetById(vehicleId);
        if (vehicle == null)
        {
            throw new SmartTransitBaseException($"Vehicle with ID {vehicleId} does not exist.");
        }

        return vehicle;
    }
}