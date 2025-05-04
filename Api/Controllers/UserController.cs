using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartTransit.Application.Resource;
using SmartTransit.Application.Resource.Login;
using SmartTransit.Application.Resource.User;
using SmartTransit.Domain.Domains.DTO;
using SmartTransit.Domain.Domains.Exceptions;
using SmartTransit.Domain.UseCases;
using SmartTransit.Domain.UseCases.Login;
using SmartTransit.Domain.UseCases.User;

namespace Api.Controllers;

[Route("api/user")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserCrudUseCases _userCrudUseCases;

    private readonly ILoginCrudUseCase _loginCrudUseCase;
    private readonly IRefreshTokenCrudUseCase _refreshTokenCrudUseCase;
    private readonly IMapper _mapper;

    public UserController(IUserCrudUseCases userCrudUseCases, IMapper mapper, ILoginCrudUseCase loginCrudUseCase,
        IRefreshTokenCrudUseCase refreshTokenCrudUseCase)
    {
        _userCrudUseCases = userCrudUseCases;
        _mapper = mapper;
        _loginCrudUseCase = loginCrudUseCase;
         _refreshTokenCrudUseCase = refreshTokenCrudUseCase;
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> RegisterUser([FromBody] UserResource userRequest)
    {
        try
        {
            var userDto = _mapper.Map<UserDTO>(userRequest);
            var createdUser = await _userCrudUseCases.RegisterUser(userDto);
            var response = _mapper.Map<UserResponseResource>(createdUser);
            return StatusCode(201, response);
        }
        catch (SmartTransitBaseException exception)
        {
            return StatusCode(exception.StatusCode, exception.Message);
        }
    }

    [HttpPost("Login")]
    [AllowAnonymous]
    public async Task<IActionResult> LoginUser([FromBody] LoginResource loginRequest)
    {
        try
        {
            var loginDto = _mapper.Map<LoginDTO>(loginRequest);
            var login = await _loginCrudUseCase.LoginUser(loginDto);
            var response = _mapper.Map<LoginResponseDTO>(login);
            ;
            return StatusCode(201, response);
        }
        catch (SmartTransitBaseException exception)
        {
            return StatusCode(exception.StatusCode, exception.Message);
        }
    }

      [HttpPost("refresh")]
      public async Task<IActionResult> Refresh([FromBody] string refreshToken)
      {
          try
          {
              var tokens = await _refreshTokenCrudUseCase.Execute(refreshToken);
              return Ok(tokens);
          }
          catch (SmartTransitBaseException exception)
          {
              return StatusCode(exception.StatusCode, exception.Message);
          }
      }
//TODO: Implementar Authorizes especificos.
    [Authorize]
    [HttpGet("{userId}")]
    public async Task<IActionResult> GetById(Guid userId)
    {
        try
        {
            var userDto = await _userCrudUseCases.GetById(userId);
            var response = _mapper.Map<UserResource>(userDto);
            return Ok(response);
        }
        catch (SmartTransitBaseException exception)
        {
            return StatusCode(exception.StatusCode, exception.Message);
        }
    }
}