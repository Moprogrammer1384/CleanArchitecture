namespace Catalog.API.Application.Dtos.Commons;

public sealed record SearchDataDto(
    string? SearchText,
    int? PageSize,
    int? PageIndex,
    string? Sort
);
