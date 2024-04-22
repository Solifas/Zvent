using System.Text.Json.Serialization;

namespace Zvent.Server.Domain.Entities;

public class User
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }

    [JsonPropertyName("email")]
    public required string Email { get; set; }

    [JsonPropertyName("fullName")]
    public required string FullName { get; set; }

    [JsonPropertyName("contact")]
    public string Contact { get; set; } = string.Empty;

    [JsonPropertyName("username")]
    public required string Username { get; set; }

    [JsonPropertyName("passwordHash")]
    public required string PasswordHash { get; set; }
}
