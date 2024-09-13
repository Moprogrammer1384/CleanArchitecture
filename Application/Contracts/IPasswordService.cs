

namespace Catalog.API.Application.Contract;

public interface IPasswordService
{
    string HashedPassword(string plainPassword);

    bool PasswordVerfication(string plainPassword, string hashedPassword);
}
