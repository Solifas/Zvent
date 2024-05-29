using MediatR;
using Zvent.Server.Domain.Enums;

namespace Zvent.Server.Usecase.Commands.GenerateTicket;

public class GenerateTicketCommand : IRequest<GenerateTicketResponse>
{
    public Guid EventId { get; set; }
    public decimal Price { get; set; }
    public Guid? UserId { get; set; }
    public bool HasAttended { get; set; }
    public TicketType TicketType { get; set; }
}

public class GenerateTicketResponse
{
    public string? TicketCode { get; set; }
    public string ErrorMessage { get; set; } = "Ticket generated successfully";
}