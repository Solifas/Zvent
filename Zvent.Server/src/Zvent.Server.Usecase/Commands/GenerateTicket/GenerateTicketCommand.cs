using MediatR;

namespace Zvent.Server.Usecase.Commands.GenerateTicket;

public class GenerateTicketCommand : IRequest<GenerateTicketResponse>
{
    public Guid EventId { get; set; }
    public Guid UserId { get; set; }
}

public class GenerateTicketResponse
{
    public string? TicketCode { get; set; }
}