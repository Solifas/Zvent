using System.Text.Json.Serialization;

namespace Zvent.Server.Domain.Entities;

public class Survey
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("eventId")]
    public int EventId { get; set; }

    [JsonPropertyName("userId")]
    public required string Comment { get; set; }
}