using System.Text.Json.Serialization;
using Zvent.Server.Domain.Enums;

namespace Zvent.Server.Domain.Entities;

public class Event
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public required string Name { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("location")]
    public string? Location { get; set; }

    [JsonPropertyName("userType")]
    public UserType UserType { get; set; }

    [JsonPropertyName("numberOfTickets")]
    public int NumberOfTickets { get; set; }

    [JsonPropertyName("startDate")]
    public DateTime StartDate { get; set; }

    [JsonPropertyName("endDate")]
    public DateTime EndDate { get; set; }
}
