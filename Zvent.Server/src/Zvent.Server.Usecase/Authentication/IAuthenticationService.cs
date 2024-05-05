using Zvent.Server.Domain.Authentication;

namespace Zvent.Server.Usecase.Authentication;

public interface IAuthenticationService
{
    Task<AuthenticationResult> Login(string username, string password);
}
