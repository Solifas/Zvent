using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Zvent.Server.Domain.Enums;

namespace Zvent.Server.Usecase.Commands.RegisterEvent;

public class RegisterEventCommand : IRequest<RegisterEventResponse>
{
    public required string Name { get; set; }
    public string? Description { get; set; }
    public string? Location { get; set; }
    public UserType UserType { get; set; }
    public int NumberOfTickets { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}

public class RegisterEventCommandValidator : AbstractValidator<RegisterEventCommand>
{
    public RegisterEventCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.NumberOfTickets).GreaterThan(0);
        RuleFor(x => x.StartDate).LessThan(x => x.EndDate);
    }
}

public class RegisterEventResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
}

