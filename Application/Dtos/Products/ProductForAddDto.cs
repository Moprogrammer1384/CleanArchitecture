
namespace Catalog.API.Application.Dtos.Products;

public sealed record ProductForAddDto(
    string Name,
    int Price,
    string? Description
);