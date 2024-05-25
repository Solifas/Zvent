using MediatR;
using FluentValidation;

namespace Zvent.Server.Usecase.Queries.GetUser;

public class GetUserQueryValidator : AbstractValidator<GetUserQuery>
{
    public GetUserQueryValidator()
    {
        RuleFor(x => x.UserName).NotEmpty();
    }
}
public class GetUserQuery : IRequest<GetUserQueryResponse>
{
    public required string UserName { get; set; }
}

public class GetUserQueryResponse
{
    public required string Email { get; set; }

    public required string FullName { get; set; }

    public string Contact { get; set; } = string.Empty;

    public required string Username { get; set; }
}
