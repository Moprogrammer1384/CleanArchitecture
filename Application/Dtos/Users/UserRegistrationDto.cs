namespace Catalog.API.Application.Dtos.Users;

public sealed record UserRegistrationDto(
    string FullName,
    string Email,
    string UserName,
    string Password
);

