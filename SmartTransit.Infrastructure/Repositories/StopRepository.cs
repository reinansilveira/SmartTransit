using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SmartTransit.Domain.Domains.DTO;
using SmartTransit.Domain.Gateway.Stop;
using SmartTransit.Infrastructure.Entities;
using SmartTransit.Infrastructure.Entities.Stop;
using SmartTransit.Infrastructure.Persistence;

namespace SmartTransit.Infrastructure.Repositories;

public class StopRepository : IStopRepositoryGateway
{
    private readonly SmartTransitDbContext _stops;
    private readonly IMapper _mapper;

    public StopRepository(SmartTransitDbContext stops, IMapper mapper)
    {
        _mapper = mapper;
        _stops = stops;
    }

    public async Task<StopDTO> Create(StopDTO stop)
    {
        var stopEntity = _mapper.Map<StopEntity>(stop);
        await _stops.StopEntities.AddAsync(stopEntity);
        await _stops.SaveChangesAsync();
        return _mapper.Map<StopDTO>(stopEntity);
    }

    public async Task<StopDTO> Update(StopDTO stop, long stopId)
    {
        var stopExist = await _stops.StopEntities.FirstOrDefaultAsync(item => item.Id == stopId);

        if (stopExist == null)
        {
            return null;
        }

        stopExist.Name = stop.Name;
        stopExist.Longitude = stop.Longitude;
        stopExist.Latitude = stop.Latitude;

        await _stops.SaveChangesAsync();
        return _mapper.Map<StopDTO>(stopExist);
    }

    public async Task<StopDTO> Delete(long stopId)
    {
        var stopEntity = await _stops.StopEntities.FindAsync(stopId);

        if (stopEntity == null)
        {
            return null;
        }

        _stops.StopEntities.Remove(stopEntity);
        await _stops.SaveChangesAsync();

        return _mapper.Map<StopDTO>(stopEntity);
    }
    public async Task<StopDTO> GetById(long stopId)
    {
        var stopEntity = await _stops.StopEntities.FirstOrDefaultAsync(item => item.Id == stopId);

        if (stopEntity == null)
        {
            return null;
        }

        return _mapper.Map<StopDTO>(stopEntity);
    }
}