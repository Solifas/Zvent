using MediatR;
using Zvent.Server.Usecase.Commands.Registration;

namespace Zvent.Server.WebApi.Endpoints;

public interface IUserEndpointDefinition
{
    void RegisterEndpoints(WebApplication app);
}
public class UserEndpointDefinition : IUserEndpointDefinition
{
    public void RegisterEndpoints(WebApplication app)
    {
        var user = app.MapGroup("/user");

        user.MapPost("/create", CreateUser);
        // user.MapGet("/get", GetUser);
    }

    private async Task<IResult> CreateUser(IMediator mediator, RegisterUserCommand request)
    {
        var result = await mediator.Send(request);
        return Results.Ok(result);
    }

    // private async Task<IResult> GetUser(IMediator mediator, GetUserCommand request)
    // {
    //     var result = await mediator.Send(request);
    //     return Results.Ok(result);
    // }
}
