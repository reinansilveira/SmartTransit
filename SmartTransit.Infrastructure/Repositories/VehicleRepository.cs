using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SmartTransit.Domain.Domains.DTO;
using SmartTransit.Domain.Gateway.Vehicle;
using SmartTransit.Infrastructure.Entities;
using SmartTransit.Infrastructure.Persistence;

namespace SmartTransit.Infrastructure.Repositories;

public class VehicleRepository : IVehicleRepositoryGateway
{
    private readonly SmartTransitDbContext _vehicles;
    private readonly IMapper _mapper;

    public VehicleRepository(SmartTransitDbContext vehicles, IMapper mapper)
    {
        _mapper = mapper;
        _vehicles = vehicles;
    }

    public async Task<VehicleDTO?> Create(VehicleDTO vehicle)
    {
        var vehicleEntity = _mapper.Map<VehicleEntity>(vehicle);
        await _vehicles.VehicleEntities.AddAsync(vehicleEntity);
        await _vehicles.SaveChangesAsync();
        return _mapper.Map<VehicleDTO>(vehicleEntity);
    }

    public async Task<VehicleDTO?> Update(VehicleDTO vehicle, long vehicleId)
    {
        var vehicleExist = await _vehicles.VehicleEntities.FirstOrDefaultAsync(item => item.Id == vehicleId);

        if (vehicleExist == null)
        {
            return null;
        }

        vehicleExist.Name = vehicle.Name;
        vehicleExist.Modelo = vehicle.Modelo;
        vehicleExist.LineId = vehicle.LineId;

        await _vehicles.SaveChangesAsync();
        return _mapper.Map<VehicleDTO>(vehicleExist);
    }

    public async Task<VehicleDTO?> Delete(long vehicleId)
    {
        var vehicleExist = await _vehicles.VehicleEntities.FindAsync(vehicleId);

        if (vehicleExist == null)
        {
            return null;
        }

        _vehicles.VehicleEntities.Remove(vehicleExist);
        await _vehicles.SaveChangesAsync();

        return _mapper.Map<VehicleDTO>(vehicleExist);
    }

    public async Task<ICollection<VehicleDTO>> GetVehiclesByLineId(long linesId)
    {
        var lineExists = await _vehicles.LineEntities.AnyAsync(item => item.Id == linesId);

        if (!lineExists)
        {
            return null;
        }

        var vehiclesWithLines = _vehicles.VehicleEntities.Where(item => item.LineId == linesId);

        return _mapper.Map<ICollection<VehicleDTO>>(vehiclesWithLines);
    }

    public async Task<VehicleDTO?> GetById(long vehicleId)
    {
        var vehicleExist = await _vehicles.VehicleEntities.FirstOrDefaultAsync(item => item.Id == vehicleId);

        if (vehicleExist == null)
        {
            return null;
        }

        return _mapper.Map<VehicleDTO>(vehicleExist);
    }
}