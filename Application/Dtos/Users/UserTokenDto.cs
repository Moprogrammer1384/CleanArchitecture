namespace Catalog.API.Application.Dtos.Users;

public sealed record UserTokenDto(
    string IdToken,
    string AccessToken
);
