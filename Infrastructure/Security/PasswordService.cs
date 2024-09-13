using System.Security.Cryptography;
using Catalog.API.Application.Contract;

namespace Catalog.API.Infrastructure.Security;

public class PasswordService : IPasswordService
{
    public string HashedPassword(string plainPassword)
    {
        byte[] salt = new byte[16];
        using (var randomGenerator = RandomNumberGenerator.Create())
        {
            randomGenerator.GetBytes(salt);
        }

        var rfcPassword = new Rfc2898DeriveBytes(plainPassword, salt, 1000, HashAlgorithmName.SHA1);
        byte[] rfcPasswordHash = rfcPassword.GetBytes(20);
        byte[] passwordHash = new byte[36];
        Array.Copy(salt, 0, passwordHash, 0, 16);
        Array.Copy(rfcPasswordHash, 0, passwordHash, 16, 20);

        return Convert.ToBase64String(passwordHash);     
    }

    public bool PasswordVerfication(string plainPassword, string hashedPassword)
    {
        byte[] dbPasswordHash = Convert.FromBase64String(hashedPassword);

        byte[] salt = new byte[16];
        Array.Copy(dbPasswordHash, 0, salt, 0, 16);

        var rfcPassword = new Rfc2898DeriveBytes(plainPassword, salt, 1000, HashAlgorithmName.SHA1);
        byte[] rfcPasswordHash = rfcPassword.GetBytes(20);

        for (int i = 0; i < rfcPasswordHash.Length; i++)
        {
            if (dbPasswordHash[i + 16] != rfcPasswordHash[i])
            {
                return false;
            }
        }

        return true;
    }
}
