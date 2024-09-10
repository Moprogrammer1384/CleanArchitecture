namespace Catalog.API.Application.Dtos.Commons;

public sealed record FilterDataDto(
    string? Filter,
    int? PageSize,
    int? PageIndex,
    string? Sort
);

