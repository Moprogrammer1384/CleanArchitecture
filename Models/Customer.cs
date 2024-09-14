using Catalog.API.Abstractions;

namespace Catalog.API.Models;

public class Customer : Entity<Guid>
{    
    public string Name { get; set; }

    public Customer()
    {
        Id = Guid.NewGuid();
    }
}
