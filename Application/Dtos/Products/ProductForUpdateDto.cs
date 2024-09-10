namespace Catalog.API.Application.Dtos.Products;

// public class ProductForUpdateDto
// {
    
// }

public sealed record ProductForUpdateDto(
    string Name,
    int Price,
    string? Description
);