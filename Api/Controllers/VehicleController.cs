using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartTransit.Application.Resource;
using SmartTransit.Application.Resource.Vehicle;
using SmartTransit.Domain.Domains.DTO;
using SmartTransit.Domain.Domains.Exceptions;
using SmartTransit.Domain.UseCases.Vehicle;

namespace Api.Controllers;

[Route("api/vehicle")]
[ApiController]
public class VehicleController : ControllerBase
{
    private readonly IVehicleCrudUseCases _vehicleCrudUseCases;
    private readonly IMapper _mapper;

    public VehicleController(IVehicleCrudUseCases vehicleCrudUseCases, IMapper mapper)
    {
        _vehicleCrudUseCases = vehicleCrudUseCases;
        _mapper = mapper;
    }
    
    [HttpPost]
    public async Task<IActionResult> Create (VehicleCreateResource vehicleRequest)
    {
        try
        {
            var vehicleDto = _mapper.Map<VehicleDTO>(vehicleRequest);
            var vehicleCreate = await _vehicleCrudUseCases.Create(vehicleDto);
            var response = _mapper.Map<VehicleResource>(vehicleCreate);
            return StatusCode(201, response);
        }
        catch (SmartTransitBaseException exception)
        {
            return StatusCode(exception.StatusCode, exception.Message);
        }
    }

    [HttpPut("{vehicleId}")]
    public async Task<IActionResult> Update (VehicleCreateResource vehicleRequest, long vehicleId)
    {
        try
        {
            var vehicleDto = _mapper.Map<VehicleDTO>(vehicleRequest);
            var vehicleUpdate = await _vehicleCrudUseCases.Update(vehicleDto, vehicleId);
            var response = _mapper.Map<VehicleResource>(vehicleUpdate);
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
            await _vehicleCrudUseCases.Delete(vehicleId);
            return StatusCode(204);
        }
        catch (SmartTransitBaseException exception)
        {
            return StatusCode(exception.StatusCode, exception.Message);
        }
    }
    
    [HttpGet("line/{linepId}")]
    public async Task<IActionResult> GetVehiclesByLineId(long linepId)
    {
        try
        {
            var vehicleDto = await _vehicleCrudUseCases.GetVehiclesByLineId(linepId);
            var response = _mapper.Map<List<VehicleResource>>(vehicleDto);
            return StatusCode(200, response);
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
            var vehicleDto = await _vehicleCrudUseCases.GetById(vehicleId);
            var response = _mapper.Map<VehicleResource>(vehicleDto);
            return StatusCode(200, response);
        }
        catch (SmartTransitBaseException exception)
        {
            return StatusCode(exception.StatusCode, exception.Message);
        }
    }
}