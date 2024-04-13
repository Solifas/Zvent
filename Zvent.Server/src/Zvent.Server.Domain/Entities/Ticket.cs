using Zvent.Server.Domain.Enums;

namespace Zvent.Server.Domain.Entities;

public class Ticket
{
    public Guid Id { get; set; }
    public int EventId { get; set; }
    public TicketType TicketType { get; set; }
    public decimal Price { get; set; }
    public Guid UserId { get; set; }
    public bool HasAttended { get; set; }

    public required Event Event { get; set; }
}