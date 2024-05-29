namespace Zvent.Server.Domain.DTOs;

public class UserDto(string email, string fullName, string contact, string username)
{
    public string Email { get; set; } = email;
    public string FullName { get; set; } = fullName;
    public string Contact { get; set; } = contact;
    public string Username { get; set; } = username;
}
