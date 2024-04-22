using System.Text;
using System.Security.Claims;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Zvent.Server.Usecase.Authentication;

namespace Zvent.Server.Infrastructure.Authentication;

public class JwtTokenGenerator(IOptions<JwtSettings> settings) : IJwtTokenGenerator
{
    private readonly JwtSettings _settings = settings.Value;

    public string GenerateToken(string username, string email)
    {
        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_settings.SecretKey)
            ), SecurityAlgorithms.HmacSha256);

        var claims = new[]{
            new Claim(JwtRegisteredClaimNames.Sub, username),
            new Claim(JwtRegisteredClaimNames.Email, email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var securityToken = new JwtSecurityToken(
            claims: claims,
            issuer: _settings.Issuer,
            expires: DateTime.UtcNow.AddMinutes(_settings.ExpiryMinutes),
            signingCredentials: signingCredentials);

        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
}
