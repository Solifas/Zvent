using System.Text.Json.Serialization;

namespace Zvent.Server.Domain.Entities;

public class User
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }
    public required string Email { get; set; }

    [JsonPropertyName("name")]
    public required string Name { get; set; }

    [JsonPropertyName("contact")]
    public string Contact { get; set; } = string.Empty;

    [JsonPropertyName("passwordHash")]
    public required string PasswordHash { get; set; }
}
