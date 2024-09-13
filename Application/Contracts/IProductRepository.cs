using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catalog.API.Models;

namespace Catalog.API.Application.Contract;

public interface IProductRepository : IRepository<Product, int>
{
    
}
