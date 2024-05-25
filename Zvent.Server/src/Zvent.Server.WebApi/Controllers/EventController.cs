using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Zvent.Server.Usecase.Commands.RegisterEvent;
using Zvent.Server.Usecase.Queries.GetEventById;

namespace Zvent.Server.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventController(ILogger<EventController> logger, IMediator mediator) : Controller
{

    [HttpPost("create-event")]
    public async Task<IActionResult> CreateEvent([FromBody] RegisterEventCommand request)
    {
        return Ok(await mediator.Send(request));
    }

    [HttpGet("get-event")]
    public async Task<IActionResult> GetEvent([FromQuery] Guid id)
    {
        return Ok(await mediator.Send(new GetEventByIdQuery { Id = id }));
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    [HttpGet("error")]
    public IActionResult Error()
    {
        return Ok("Error!");
    }
}
