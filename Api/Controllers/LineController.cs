using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartTransit.Application.Resource;
using SmartTransit.Application.Resource.Line;
using SmartTransit.Domain.Domains.DTO;
using SmartTransit.Domain.Domains.Exceptions;
using SmartTransit.Domain.UseCases;

namespace Api.Controllers;

[Route("api/line")]
[ApiController]
public class LineController : ControllerBase
{
    private readonly ILineCrudUseCases _lineCrudUseCases;
    private readonly IMapper _mapper;

    public LineController(ILineCrudUseCases lineCrudUseCases, IMapper mapper)
    {
        _lineCrudUseCases = lineCrudUseCases;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> Create(LineCreateResource lineRequest)
    {
        try
        {
            var lineDto = _mapper.Map<LineCreateDTO>(lineRequest);
            var lineCreate = await _lineCrudUseCases.Create(lineDto);
            var response = _mapper.Map<LineResponseResource>(lineCreate);
            return StatusCode(201, response);
        }
        catch (SmartTransitBaseException exception)
        {
            return StatusCode(exception.StatusCode, exception.Message);
        }
    }

    [HttpPut("{lineId}")]
    public async Task<IActionResult> Update(LineCreateResource request, long lineId)
    {
        try
        {
            var lineDto = _mapper.Map<LineCreateDTO>(request);
            var lineUpdateDto = await _lineCrudUseCases.Update(lineDto, lineId);
            var response = _mapper.Map<LineResource>(lineUpdateDto);
            return StatusCode(200, response);
        }
        catch (SmartTransitBaseException exception)
        {
            return StatusCode(exception.StatusCode, exception.Message);
        }
    }

    [HttpDelete("{lineId}")]
    public async Task<IActionResult> Delete(long lineId)
    {
        try
        {
            await _lineCrudUseCases.Delete(lineId);
            return StatusCode(204);
        }
        catch (SmartTransitBaseException exception)
        {
            return StatusCode(exception.StatusCode, exception.Message);
        }
    }

    [HttpGet("stop/{stopId}")]
    public async Task<IActionResult> GetLinesByStopId(long stopId)
    {
        try
        {
            var lineDto = await _lineCrudUseCases.GetLinesByStopId(stopId);
            var response = _mapper.Map<List<LineResponseResource>>(lineDto);
            return StatusCode(200, response);
        }
        catch (SmartTransitBaseException exception)
        {
            return StatusCode(exception.StatusCode, exception.Message);
        }
    }
    
    [HttpGet("{lineId}")]
    public async Task<IActionResult> GetById(long lineId)
    {
        try
        {
            var lineDto = await _lineCrudUseCases.GetById(lineId);
            var response = _mapper.Map<LineResource>(lineDto);
            return StatusCode(200, response);
        }
        catch (SmartTransitBaseException exception)
        {
            return StatusCode(exception.StatusCode, exception.Message);
        }
    }
}