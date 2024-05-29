using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Zvent.Server.Usecase.Authentication;

public interface IUserClaimsService
{
    void SetClaim(string claimType, string value);
    string GetClaim(string claimType);
}