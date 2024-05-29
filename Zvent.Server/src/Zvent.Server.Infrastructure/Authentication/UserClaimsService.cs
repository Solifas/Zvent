

using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Zvent.Server.Usecase.Authentication;

namespace Zvent.Server.Infrastructure.Authentication;

public class UserClaimsService : IUserClaimsService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UserClaimsService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public void SetClaim(string claimType, string value)
    {
        if (_httpContextAccessor?.HttpContext?.User.Identity is ClaimsIdentity identity)
        {
            var existingClaim = identity.FindFirst(claimType);
            if (existingClaim != null)
            {
                identity.RemoveClaim(existingClaim);
            }
            identity.AddClaim(new Claim(claimType, value));
        }
        else
        {
            throw new InvalidOperationException("User claims not available.");
        }
    }

    public string GetClaim(string claimType)
    {
        if (_httpContextAccessor?.HttpContext?.User.Identity is not ClaimsIdentity identity)
        {
            throw new InvalidOperationException("User claims not available.");
        }
        var claim = identity.FindFirst(claimType);
        if (claim == null) return string.Empty;
        return claim.Value;
    }
}
