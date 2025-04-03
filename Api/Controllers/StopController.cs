using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartTransit.Application.Resource;
using SmartTransit.Domain.Domains.DTO;
using SmartTransit.Domain.Domains.Exceptions;
using SmartTransit.Domain.UseCases.Stop;

namespace Api.Controllers;

[Route("api/stop")]
[ApiController]
public class StopController : ControllerBase
{
    private readonly IStopCrudUseCases _stopCrudUseCases;
    private readonly IMapper _mapper;

    public StopController(IStopCrudUseCases stopCrudUseCases, IMapper mapper)
    {
        _stopCrudUseCases = stopCrudUseCases;
        _mapper = mapper;
    }
    
    [HttpPost]
    public async Task<IActionResult> Create (StopResource stopRequest)
    {
        try
        {
            var stopDto = _mapper.Map<StopDTO>(stopRequest);
            var stopCreate = await _stopCrudUseCases.Create(stopDto);
            var response = _mapper.Map<StopResource>(stopCreate);
            return StatusCode(201, response);
        }
        catch (SmartTransitBaseException exception)
        {
            return StatusCode(exception.StatusCode, exception.Message);
        }
    }

    [HttpPut("{stopId}")]
    public async Task<IActionResult> Update (StopResource request, long stopId)
    {
        try
        {
            var stopDto = _mapper.Map<StopDTO>(request);
            var stopUpdate = await _stopCrudUseCases.Update(stopDto, stopId);
            var response = _mapper.Map<LineResource>(stopUpdate);
            return StatusCode(200, response);
        }
        catch (SmartTransitBaseException exception)
        {
            return StatusCode(exception.StatusCode, exception.Message);
        }
    }

    [HttpDelete("{stopId}")]
    public async Task<IActionResult> Delete (long stopId)
    {
        try
        {
            await _stopCrudUseCases.Delete(stopId);
            return StatusCode(204);
        }
        catch (SmartTransitBaseException exception)
        {
            return StatusCode(exception.StatusCode, exception.Message);
        }
    }

    [HttpGet("{stopId}")]
    public async Task<IActionResult> GetById(long stopId)
    {
        try
        {
            var stopDto = await _stopCrudUseCases.GetById(stopId);
            var response = _mapper.Map<StopResource>(stopId);
            return StatusCode(200, response);
        }
        catch (SmartTransitBaseException exception)
        {
            return StatusCode(exception.StatusCode, exception.Message);
        }
    }
}