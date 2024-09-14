namespace Catalog.API.Application.Dtos.Products;

public sealed record ProductForUpdateDto(
    string Name,
    int Price,
    string? Description
);