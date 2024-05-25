using FluentValidation;
using MediatR;
using Zvent.Server.Domain.Entities;

namespace Zvent.Server.Usecase.Queries.GetUsers;

public class GetUsersQuery : IRequest<GetUsersQueryResponse>
{
    public int Page { get; set; }
    public int PageSize { get; set; }
}

public class GetUsersQueryResponse
{
    public int TotalCount { get; set; }
    public List<User> Users { get; set; } = [];
}

public class GetUsersQueryValidator : AbstractValidator<GetUsersQuery>
{
    public GetUsersQueryValidator()
    {
        RuleFor(x => x.Page).GreaterThan(0);
        RuleFor(x => x.PageSize).GreaterThan(0);
    }
}
