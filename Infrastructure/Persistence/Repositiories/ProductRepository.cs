using Catalog.API.Application.Contract;
using Catalog.API.Application.Contract.Data;
using Catalog.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Catalog.API.Infrastructure.Persistence.Repositiories;

public class ProductRepository : SqlRepository<Product, int>, IProductRepository
{
    public ProductRepository(CatalogContext context) : base(context)
    {
        
    }

    public override async Task<PagedList<Product>> SearchAsync(SearchData data)
    {
        return await _set
                         .AsNoTracking()
                         .Where(product => EF.Functions.Like(product.Name, $"%{data.SearchText}%") ||
                                           EF.Functions.Like(product.Description, $"%{data.SearchText}%") ||
                                           EF.Functions.Like(product.Id.ToString(), $"%{data.SearchText}%"))
                         .Sort(data.Sort)
                         .PageAsync<Product>(data.PageSize, data.PageIndex);                  
    }
}
