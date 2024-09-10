using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
