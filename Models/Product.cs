using Catalog.API.Abstractions;

namespace Catalog.API.Models;

public class Product : Entity<int>
{
    public string Name { get; set; }
    public int Price { get; set; }
    public string? Description { get; set; }    

    // Other Properties

    // public Product(
    //     string name, 
    //     int price,
    //     string description)
    // {
    //     // Gaurd Conditions
    //     this.Name = name;
    //     this.Price = price;
    //     this.Description = description;
    // }
}

