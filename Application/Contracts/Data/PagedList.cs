namespace Catalog.API.Application.Contract.Data;

public class PagedList<TEntity>
{
    private List<TEntity> _items = [];
    public IReadOnlyList<TEntity> Items => _items.AsReadOnly();    
    public PagingData Data { get; init; }
    public PagedList(
        IEnumerable<TEntity> items,
        int pageSize,
        int pageIndex,
        int totalRecordCount)
    {
        _items.AddRange(items);
        Data = new PagingData(pageSize, pageIndex, totalRecordCount);
    }
}
