using System.Linq.Dynamic.Core;
using Catalog.API.Application.Contract.Data;
using Microsoft.EntityFrameworkCore;

namespace Catalog.API.Infrastructure.Persistence;

public static class DbSetExtension
{
    private const int DefaultPageSize = 10;
    private const int MaxPageSize = 100;
    public static IQueryable<TEntity> Filter<TEntity>(
        this IQueryable<TEntity> query,
        string? filter)
    {
        if(string.IsNullOrEmpty(filter))
        {
            return query;
        }
        
        return query.Where(filter);
    }
        
    public static async Task<PagedList<TEntity>> PageAsync<TEntity>(
        this IQueryable<TEntity> query,
        int? pageSize,
        int? pageIndex)
    {        
        if (!pageSize.HasValue)
        {
            pageSize = DefaultPageSize;
        }
        else
        {
            pageSize = pageSize.Value;
            if(pageSize > MaxPageSize)
            {
                pageSize = MaxPageSize;
            }
        }

        if (!pageIndex.HasValue)
        {
            pageIndex = 1;
        }

        var totalRecordCount = await query.CountAsync();
        var items = await query
                            .Skip((pageIndex.Value - 1) * pageSize.Value)
                            .Take(pageSize.Value)
                            .ToListAsync();

        var pagedList = new PagedList<TEntity>(items, 
                                              pageSize.Value, 
                                              pageIndex.Value,
                                              totalRecordCount); 

        return pagedList;                                                                          
    }

    public static IQueryable<TEntity> Sort<TEntity>(
        this IQueryable<TEntity> query,
        string? sort)
    {
        if(string.IsNullOrEmpty(sort))
        {
            return query;
        }
        
        return query.OrderBy(sort);
    }
}
