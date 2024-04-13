namespace Zvent.Server.Domain.Entities;

public class User
{
    public Guid Id { get; set; }
    public required string Email { get; set; }
    public required string Name { get; set; }
    public string Contact { get; set; } = string.Empty;
    public required string PasswordHash { get; set; }
}
