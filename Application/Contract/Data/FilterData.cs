namespace Catalog.API.Application.Contract.Data;

public sealed record FilterData(
    string? Filter,
    int? PageSize,
    int? PageIndex,
    string? Sort
);

