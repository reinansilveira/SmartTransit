using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SmartTransit.Domain.Domains.DTO;
using SmartTransit.Domain.Gateway.Line;
using SmartTransit.Infrastructure.Entities;
using SmartTransit.Infrastructure.Persistence;

namespace SmartTransit.Infrastructure.Repositories;

public class LineRepository : ILineRepositoryGateway
{
    private readonly SmartTransitDbContext _lines;
    private readonly IMapper _mapper;

    public LineRepository(SmartTransitDbContext lines, IMapper mapper)
    {
        _mapper = mapper;
        _lines = lines;
    }

    public async Task<LineResponseDTO> Create(LineCreateDTO line)
    {
        var lineEntity = _mapper.Map<LineEntity>(line);
        var stopList = await GetStops(line.Stops);

        lineEntity.Stops = stopList;

        await _lines.LineEntities.AddAsync(lineEntity);
        await _lines.SaveChangesAsync();

        return _mapper.Map<LineResponseDTO>(lineEntity);
    }

    public async Task<LineDTO?> Update(LineCreateDTO line, long lineId)
    {
        var lineExist = await _lines.LineEntities.FirstOrDefaultAsync(item => item.Id == lineId);

        if (lineExist == null)
        {
            return null;
        }

        lineExist.Name = line.Name;
        await _lines.SaveChangesAsync();
        return _mapper.Map<LineDTO>(lineExist);
    }

    public async Task<LineDTO?> Delete(long lineId)
    {
        var line = await _lines.LineEntities.FindAsync(lineId);

        if (line == null)
        {
            return null;
        }

        _lines.LineEntities.Remove(line);
        await _lines.SaveChangesAsync();

        return _mapper.Map<LineDTO>(line);
    }

    public async Task<ICollection<LineResponseDTO>> GetLinesByStopId(long stopId)
    {
        var stopExistsInDatabase = await _lines.StopEntities.AnyAsync(item => item.Id == stopId);

        if (!stopExistsInDatabase)
        {
            return null;
        }

        var linesWithStop = await _lines.LineEntities
            .FromSqlInterpolated($@"
            SELECT * 
            FROM LineEntities 
            WHERE JSON_CONTAINS(StopsJson, JSON_OBJECT('Id', {stopId}))
        ")
            .ToListAsync();

        return _mapper.Map<ICollection<LineResponseDTO>>(linesWithStop);
    }

    public async Task<LineDTO?> GetById(long lineId)
    {
        var lineEntity = await _lines.LineEntities.FirstOrDefaultAsync(item => item.Id == lineId);

        if (lineEntity == null)
        {
            return null;
        }

        return _mapper.Map<LineDTO>(lineEntity);
    }

    private async Task<ICollection<StopEntity>> GetStops(ICollection<long> stopsIds)
    {
        var stops = new List<StopEntity>();
        foreach (var stopId in stopsIds)
        {
            var stop = await _lines.StopEntities.FirstOrDefaultAsync(s => s.Id == stopId);

            if (stop != null)
            {
                stops.Add(stop);
            }
        }

        return stops;
    }
}