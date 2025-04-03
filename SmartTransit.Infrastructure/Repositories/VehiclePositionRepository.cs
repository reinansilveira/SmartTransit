using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SmartTransit.Domain.Domains.DTO;
using SmartTransit.Domain.Gateway.VehiclePosition;
using SmartTransit.Infrastructure.Entities;
using SmartTransit.Infrastructure.Persistence;

namespace SmartTransit.Infrastructure.Repositories;

public class VehiclePositionRepository : IVehiclePositionRepositoryGateway
{
    private readonly SmartTransitDbContext _vehiclePositions;
    private readonly IMapper _mapper;

    public VehiclePositionRepository(SmartTransitDbContext vehiclesPosition, IMapper mapper)
    {
        _mapper = mapper;
        _vehiclePositions = vehiclesPosition;
    }
    public async Task<VehiclePositionDTO?> Create(VehiclePositionDTO vehicle)
    {
        var vehiclePositionEntity = _mapper.Map<VehiclePositionEntity>(vehicle);
        await _vehiclePositions.VehiclePositionEntities.AddAsync(vehiclePositionEntity);
        await _vehiclePositions.SaveChangesAsync();
        return _mapper.Map<VehiclePositionDTO>(vehiclePositionEntity);
    }

    public async Task<VehiclePositionDTO?> Update(VehiclePositionDTO vehicle, long vehicleId)
    {
        var vehiclePositionExist= await _vehiclePositions.VehiclePositionEntities.FirstOrDefaultAsync(item => item.VehicleId == vehicleId);

        if (vehiclePositionExist == null)
        {
            return null;
        }

        vehiclePositionExist.VehiclePosition = vehicle.VehiclePosition;
        vehiclePositionExist.Longitude = vehicle.Longitude;
        vehiclePositionExist.VehicleId = vehicle.VehicleId;

        await _vehiclePositions.SaveChangesAsync();
        return _mapper.Map<VehiclePositionDTO>(vehiclePositionExist);
    }

    public async Task<VehiclePositionDTO?> Delete(long vehicleId)
    {
        var vehiclePositionExist = await _vehiclePositions.VehiclePositionEntities.FindAsync(vehicleId);

        if (vehiclePositionExist == null)
        {
            return null;
        }

         _vehiclePositions.VehiclePositionEntities.Remove(vehiclePositionExist);
        await _vehiclePositions.SaveChangesAsync();

        return _mapper.Map<VehiclePositionDTO>(vehiclePositionExist);
    }

    public async Task<VehiclePositionDTO?> GetById(long vehicleId)
    {
        var vehicleExist = await _vehiclePositions.VehiclePositionEntities.FirstOrDefaultAsync(item => item.VehicleId == vehicleId);

        if (vehicleExist == null)
        {
            return null;
        }

        return _mapper.Map<VehiclePositionDTO>(vehicleExist);
    }
}