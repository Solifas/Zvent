
using System.Security.Claims;
using AutoMapper;
using Zvent.Server.Domain.Authentication;
using Zvent.Server.Domain.DTOs;
using Zvent.Server.Usecase.Encryption;
using Zvent.Server.Usecase.Persistance.Interfaces;

namespace Zvent.Server.Usecase.Authentication;
public class AuthenticationService(IJwtTokenGenerator jwtToken, IUserRepository userRepository,
IEncryptionService encryptionService, IMapper mapper,
IUserClaimsService userClaimsService) : IAuthenticationService
{
    public async Task<AuthenticationResult> Login(string username, string password)
    {
        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            return new AuthenticationResult(string.Empty, null, "Username and password are required");
        }


        var user = await userRepository.GetUser(username);
        if (user == null)
        {
            return new AuthenticationResult(string.Empty, null, "Username or password is incorrect");
        }

        var passwordHash = encryptionService.GetSha256Hash(password);

        if (user.PasswordHash != passwordHash)
        {
            return new AuthenticationResult(string.Empty, null, "Username or password is incorrect");
        }

        var token = jwtToken.GenerateToken(user.Username, user.Email);

        userClaimsService.SetClaim(ClaimTypes.Name, user.Username);
        userClaimsService.SetClaim(ClaimTypes.Email, user.Email);
        userClaimsService.SetClaim(ClaimTypes.MobilePhone, user.Contact);

        var userDto = mapper.Map<UserDto>(user);

        return new AuthenticationResult(token, userDto);
    }
}


