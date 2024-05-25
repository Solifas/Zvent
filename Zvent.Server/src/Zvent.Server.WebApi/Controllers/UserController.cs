using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Amazon.DynamoDBv2.Model;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Zvent.Server.Usecase.Commands.Registration;
using Zvent.Server.Usecase.Queries.GetUser;
using Zvent.Server.Usecase.Queries.GetUsers;

namespace Zvent.Server.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController(ILogger<UserController> logger, IMediator mediator) : Controller
{

    [HttpGet("get-user")]
    public IActionResult GetUser(GetUserQuery request)
    {
        return View(mediator.Send(request));
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] RegisterUserCommand request)
    {
        return View(await mediator.Send(request));
    }

    [HttpGet("get-users")]
    public async Task<IActionResult> GetUsers(GetUsersQuery request)
    {
        return View(await mediator.Send(request));
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    [HttpGet("error")]
    public IActionResult Error()
    {
        return View("Error!");
    }
}
