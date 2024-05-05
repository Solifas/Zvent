using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Zvent.Server.Usecase.Encryption;

public interface IEncryptionService
{
    public string GetSha256Hash(string input);
    public string DecryptSha256Hash(string input);
}
