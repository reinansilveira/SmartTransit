using SmartTransit.Domain.Domains.DTO;
using SmartTransit.Domain.Domains.Exceptions;
using SmartTransit.Domain.Gateway.Line;
using SmartTransit.Domain.Gateway.Stop;
using SmartTransit.Domain.UseCases;
using SmartTransit.Domain.UseCases.Line;

namespace SmartTransit.Domain.Services;

public class LineCrudUseService : ILineCrudUseCases
{
    private readonly ILineRepositoryGateway _lineRepositoryGateway;
    private readonly IStopRepositoryGateway _stopRepositoryGateway;

    public LineCrudUseService(ILineRepositoryGateway lineRepositoryGateway,
        IStopRepositoryGateway stopRepositoryGateway)
    {
        _lineRepositoryGateway = lineRepositoryGateway;
        _stopRepositoryGateway = stopRepositoryGateway;
    }

    public async Task<LineResponseDTO> Create(LineCreateDTO line)
    {
        await ValidateStopsExist(line);
        return await _lineRepositoryGateway.Create(line);
    }

    public async Task<LineDTO?> AddStop(LineCreateDTO line, long lineId)
    {
        await EnsureLineExists(lineId);

        await ValidateStopsExist(line);

        var existingStopIds = (await GetLineStopIds(lineId)).ToHashSet();
        var duplicateStops = line.Stops.Where(stopId => existingStopIds.Contains(stopId.ToString())).ToList();

        if (duplicateStops.Any())
        {
            throw new LineDoesNotExisException(400, "One or more stop IDs are already present in the line.");
        }

        return await _lineRepositoryGateway.AddStop(line, lineId);
    }

    public async Task<LineDTO?> RemoveStop(LineCreateDTO line, long lineId)
    {
        await EnsureLineExists(lineId);

        await ValidateStopsExist(line);

        var existingStopIds = (await GetLineStopIds(lineId)).ToHashSet();
        var missingStops = line.Stops.Where(stopId => !existingStopIds.Contains(stopId.ToString())).ToList();

        if (missingStops.Any())
        {
            throw new LineDoesNotExisException(400, "One or more stop IDs are not part of the line.");
        }

        return await _lineRepositoryGateway.RemoveStop(line, lineId);
    }

    public async Task<LineDTO> Update(LineCreateDTO line, long lineId)
    {
        await ValidateStopsExist(line);

        var updatedLine = await _lineRepositoryGateway.Update(line, lineId);
        if (updatedLine == null)
        {
            throw new StopDoesNotExistException(404,
                "The requested line ID does not match any stop registered in the system.");
        }

        return updatedLine;
    }

    public async Task<LineDTO> Delete(long lineId)
    {
        await EnsureLineExists(lineId);
        return await _lineRepositoryGateway.Delete(lineId);
    }

    public async Task<ICollection<LineResponseDTO>> GetLinesByStopId(long stopId)
    {
        return await _lineRepositoryGateway.GetLinesByStopId(stopId);
    }

    public async Task<LineDTO> GetById(long lineId)
    {
        
        return await EnsureLineExists(lineId);
    }

    private async Task ValidateStopsExist(LineCreateDTO line)
    {
        foreach (var stops in line.Stops)
        {
            var existingStop = await _stopRepositoryGateway.GetById(stops);

            if (existingStop == null)
            {
                throw new StopDoesNotExistException(404,
                    "The requested stop ID does not match any stop registered in the system.");
            }
        }
    }

    private async Task<LineDTO> EnsureLineExists(long lineId)
    {
        var line = await _lineRepositoryGateway.GetById(lineId);
        if (line == null)
        {
            throw new LineDoesNotExisException(404, $"Line with ID {lineId} does not exist.");
        }

        return line;
    }

    private async Task<List<string>> GetLineStopIds(long lineId)
    {
        var line = await _lineRepositoryGateway.GetById(lineId);
        if (line == null)
        {
            throw new LineDoesNotExisException(404, $"Line with ID {lineId} not found.");
        }

        return line.Stops.Select(stop => stop.Id.ToString()).ToList();
    }
}