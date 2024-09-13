
using Catalog.API.Application.Dtos.Users;
using CSharpFunctionalExtensions;

namespace Catalog.API.Application.Contract;

// Result Pattern
public interface IUserService
{
    Task<Result> RegisterUserAsync(UserRegistrationDto userRegistrationDto);
    Task<Result<UserTokenDto>> LoginUserAsync(UserLoginDto userLoginDto);
}
