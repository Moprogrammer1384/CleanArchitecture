using System.Linq.Expressions;
using Catalog.API.Abstractions;
using Catalog.API.Application.Contract;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using Catalog.API.Application.Contract.Data;

namespace Catalog.API.Infrastructure.Persistence.Repositiories;

public abstract class SqlRepository<TEntity, TId> : IRepository<TEntity, TId>
where TEntity : Entity<TId>
{
    
    private readonly DbContext _context;
    protected readonly DbSet<TEntity> _set;
    public SqlRepository(DbContext context)
    {
        this._context = context;
        this._set = _context.Set<TEntity>();
    }
    public async Task AddAsync(TEntity entity)
    {
        await _context.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(TEntity entity)
    {
        _context.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<TEntity>> FilterAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await _set.Where(predicate).ToListAsync();
    }

    public async Task<PagedList<TEntity>> FilterAsync(FilterData data)
    {                      
        return await _set
                         .AsNoTracking()
                         .Sort(data.Sort)
                         .Filter(data.Filter)
                         .PageAsync(data.PageSize, data.PageIndex);
    }

    public async Task<TEntity?> GetByIdAsync(TId id)
    {
        return await _set.FindAsync(id);
    }

    public async Task<IEnumerable<TEntity>> GetEntitiesAsync()
    {
        return await _set.ToListAsync();
    }

    public virtual Task<PagedList<TEntity>> SearchAsync(SearchData data)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateAsync(TEntity entity)
    {
        var proxyEntity = _context.Entry(entity);
        proxyEntity.State = EntityState.Modified;

        await _context.SaveChangesAsync();
    }
}
