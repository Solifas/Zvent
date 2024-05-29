using MediatR;
using Microsoft.AspNetCore.Mvc;
using Zvent.Server.Domain.DTOs;
using Zvent.Server.Usecase.Authentication;
using Zvent.Server.Usecase.Commands.Registration;

namespace Zvent.Server.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(IAuthenticationService authenticationService, IMediator mediator) : ControllerBase
{
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterUserCommand command)
    {
        try
        {
            var response = await mediator.Send(command);
            return Ok(response);
        }
        catch (System.Exception ex)
        {
            throw;
        }
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest command)
    {
        var response = await authenticationService.Login(command.Username, command.Password);
        return Ok(response);
    }
}
