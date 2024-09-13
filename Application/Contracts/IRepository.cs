using System.Linq.Expressions;
using Catalog.API.Application.Contract.Data;
using Catalog.API.Application.Contracts;

namespace Catalog.API.Application.Contract;

public interface IRepository<TEntity, TId> 
where TEntity : IEntity<TId>
{
    Task AddAsync(TEntity entity);
    Task UpdateAsync(TEntity entity);
    Task DeleteAsync(TEntity entity);
    Task<TEntity?> GetByIdAsync(TId id);
    Task<IEnumerable<TEntity>> GetEntitiesAsync();
    Task<IEnumerable<TEntity>> FilterAsync(Expression<Func<TEntity, bool>> predicate);                                   
    Task<PagedList<TEntity>> FilterAsync(FilterData data);                                    
    Task<PagedList<TEntity>> SearchAsync(SearchData data);                                    
}
