
namespace Catalog.API.Application.Dtos.Products;

// Immutable implementation
// public sealed class ProductForAddDto
// {    
//     public string? Name { get; init; }
//     public int Price { get; init; }
//     public string? Description { get; init; }   
//     public ProductForAddDto(
//         string name,
//         int price, 
//         string description)
//     {
//         this.Name = name;
//         this.Price = price;
//         this.Description = description;
//     }
// }

// Records

public sealed record ProductForAddDto(
    string Name,
    int Price,
    string? Description
);