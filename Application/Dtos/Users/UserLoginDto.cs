
namespace Catalog.API.Application.Dtos.Users;

public sealed record UserLoginDto(
    string UserName,
    string Password
);

