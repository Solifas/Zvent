namespace Zvent.Server.Domain.Authentication;

public class AuthenticationResult(string token, string username, string email)
{
    public string Token { get; } = token;
    public string Username { get; } = username;
    public string Email { get; } = email;
}
