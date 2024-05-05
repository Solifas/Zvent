namespace Zvent.Server.Usecase.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(string username, string email);
}


