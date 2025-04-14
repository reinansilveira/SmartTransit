using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartTransit.Application.Resource;
using SmartTransit.Application.Resource.VehiclePosition;
using SmartTransit.Domain.Domains.DTO;
using SmartTransit.Domain.Domains.Exceptions;
using SmartTransit.Domain.UseCases.VehiclePosition;

namespace Api.Controllers;

[Route("api/vehicle-position")]
[ApiController]
public class VehiclePositionController : ControllerBase
{
    private readonly IVehiclePositionCrudUseCases _vehiclePositionCrudUseCases;
    private readonly IMapper _mapper;

    public VehiclePositionController(IVehiclePositionCrudUseCases vehiclePositionCrudUseCases, IMapper mapper)
    {
        _vehiclePositionCrudUseCases = vehiclePositionCrudUseCases;
        _mapper = mapper;
    }
    
    [HttpPost]
    public async Task<IActionResult> Create (VehiclePositionResource vehiclePositionRequest)
    {
        try
        {
            var vehiclePositionDto = _mapper.Map<VehiclePositionDTO>(vehiclePositionRequest);
            var vehiclePositionCreate = await _vehiclePositionCrudUseCases.Create(vehiclePositionDto);
            var response = _mapper.Map<VehiclePositionResource>(vehiclePositionCreate);
            return StatusCode(201, response);
        }
        catch (SmartTransitBaseException exception)
        {
            return StatusCode(exception.StatusCode, exception.Message);
        }
    }

    [HttpPut("{vehicleId}")]
    public async Task<IActionResult> Update (VehiclePositionResource request, long vehicleId)
    {
        try
        {
            var vehiclePositionDto = _mapper.Map<VehiclePositionDTO>(request);
            var vehicleUpdate = await _vehiclePositionCrudUseCases.Update(vehiclePositionDto, vehicleId);
            var response = _mapper.Map<VehiclePositionResource>(vehicleUpdate);
            return StatusCode(200, response);
        }
        catch (SmartTransitBaseException exception)
        {
            return StatusCode(exception.StatusCode, exception.Message);
        }
    }

    [HttpDelete("{vehicleId}")]
    public async Task<IActionResult> Delete (long vehicleId)
    {
        try
        {
            await _vehiclePositionCrudUseCases.Delete(vehicleId);
            return StatusCode(204);
        }
        catch (SmartTransitBaseException exception)
        {
            return StatusCode(exception.StatusCode, exception.Message);
        }
    }

    [HttpGet("{vehicleId}")]
    public async Task<IActionResult> GetById(long vehicleId)
    {
        try
        {
            var vehicleDto = await _vehiclePositionCrudUseCases.GetById(vehicleId);
            var response = _mapper.Map<VehiclePositionResource>(vehicleDto);
            return StatusCode(200, response);
        }
        catch (SmartTransitBaseException exception)
        {
            return StatusCode(exception.StatusCode, exception.Message);
        }
    }
}