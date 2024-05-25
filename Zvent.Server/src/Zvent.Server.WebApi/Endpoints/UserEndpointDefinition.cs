using MediatR;
using Microsoft.AspNetCore.Mvc;
using Zvent.Server.Usecase.Queries.GetUser;
using Zvent.Server.Usecase.Commands.Registration;

namespace Zvent.Server.WebApi.Endpoints;

public interface IUserEndpointDefinition
{
    // void RegisterEndpoints(WebApplication app);
    Task<IResult> CreateUser(IMediator mediator, [FromBody] RegisterUserCommand request);
    Task<IResult> GetUser(IMediator mediator, GetUserQuery request);
}
public class UserEndpointDefinition : IUserEndpointDefinition
{
    // public void RegisterEndpoints(WebApplication app)
    // {
    //     var user = app.MapGroup("/user");

    //     user.MapPost("/create", CreateUser);
    //     user.MapGet("/get-user", GetUser);
    // }

    public async Task<IResult> CreateUser(IMediator mediator, [FromBody] RegisterUserCommand request)
    {
        var result = await mediator.Send(request);
        return Results.Ok(result);
    }

    public async Task<IResult> GetUser(IMediator mediator, GetUserQuery request)
    {
        var result = await mediator.Send(request);
        return Results.Ok(result);
    }
}
