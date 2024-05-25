using MediatR;
using FluentValidation;
using Zvent.Server.Domain.Entities;
using Zvent.Server.Domain.Enums;

namespace Zvent.Server.Usecase.Queries.GetEventById;

public class GetEventByIdQuery : IRequest<EventByIdResponse>
{
    public Guid Id { get; set; }
}

public class GetEventByIdQueryValidator : AbstractValidator<GetEventByIdQuery>
{
    public GetEventByIdQueryValidator()
    {
        RuleFor(x => x.Id).NotNull();
    }
}

public class EventByIdResponse
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    public string? Location { get; set; }

    public UserType UserType { get; set; }

    public int NumberOfTickets { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }
}
