namespace Catalog.API.Application.Contract.Data;

public class PagingData
{
    public int CurrentPage { get; init; }
    public int PageSize { get; init; }
    public int TotalRecordCount { get; init; }
    public int PageCount => (int) Math.Ceiling((double) TotalRecordCount / PageSize);
    public bool HasNext => CurrentPage < PageCount;
    public bool HasPrevious => CurrentPage > 1;

    public PagingData(
        int pageSize,
        int pageIndex,
        int totalRecordCount
    )
    {
        this.PageSize = pageSize;
        this.CurrentPage = pageIndex;
        this.TotalRecordCount = totalRecordCount;
    }
}
