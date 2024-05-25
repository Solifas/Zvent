using FluentValidation;
using MediatR;
using Zvent.Server.Domain.Entities;

namespace Zvent.Server.Usecase.Queries.GetEvents;

public class GetEventsQuery : IRequest<GetEventsQueryResponse>
{
    public int Page { get; set; }
    public int PageSize { get; set; }
}

public class GetEventsQueryResponse
{
    public int TotalCount { get; set; }
    public List<Event> Events { get; set; } = [];
}

public class GetEventsQueryValidator : AbstractValidator<GetEventsQuery>
{
    public GetEventsQueryValidator()
    {
        RuleFor(x => x.Page).GreaterThan(0);
        RuleFor(x => x.PageSize).GreaterThan(0);
    }
}

