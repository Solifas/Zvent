using Zvent.Server.Usecase.Encryption;

namespace Zvent.Server.Infrastructure.Encryption;

public class EncryptionService : IEncryptionService
{
    public string GetSha256Hash(string input)
    {
        var bytes = System.Text.Encoding.UTF8.GetBytes(input);
        var hash = System.Security.Cryptography.SHA256.HashData(bytes);
        return Convert.ToBase64String(hash);
    }

    public string DecryptSha256Hash(string input)
    {
        var bytes = Convert.FromBase64String(input);
        var hash = System.Security.Cryptography.SHA256.HashData(bytes);
        return System.Text.Encoding.UTF8.GetString(hash);
    }
}
