using Zvent.Server.Domain.DTOs;

namespace Zvent.Server.Domain.Authentication;

//add a generic class of type T

public class AuthenticationResult(string token, UserDto? user = null, string? errorMessage = "")
{

    public string Token { get; } = token;
    public bool IsAuthenticated { get; } = !string.IsNullOrEmpty(token);
    public string? ErrorMessage { get; } = errorMessage;
    public UserDto? Data { get; set; } = user;
}