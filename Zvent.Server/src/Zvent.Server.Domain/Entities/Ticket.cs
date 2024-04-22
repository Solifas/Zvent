using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Zvent.Server.Domain.Enums;

namespace Zvent.Server.Domain.Entities;

public class Ticket
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; } = Guid.NewGuid();

    [JsonPropertyName("eventId")]
    public int EventId { get; set; }

    [JsonPropertyName("ticketType")]
    public TicketType TicketType { get; set; }

    [JsonPropertyName("price")]
    public decimal Price { get; set; }

    [JsonPropertyName("userId")]
    public Guid? UserId { get; set; }

    [JsonPropertyName("ticketCode")]
    public bool HasAttended { get; set; }

    [IgnoreDataMember]
    public required Event Event { get; set; }
}