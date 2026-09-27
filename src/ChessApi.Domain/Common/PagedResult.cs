namespace ChessApi.Domain.Common;

/// <summary>
/// Standardized wrapper for paginated collections and pagination metadata.
/// </summary>
public class PagedResult<T>
{
    public IReadOnlyList<T> Items { get; }
    public int PageNumber { get; }
    public int PageSize { get; }
    public int TotalCount { get; }
    public int TotalPages { get; }
    public bool HasPreviousPage => PageNumber > 1;
    public bool HasNextPage => PageNumber < TotalPages;

    public PagedResult(IReadOnlyList<T> items, int count, int pageNumber, int pageSize)
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
        TotalCount = count;
        TotalPages = (int)Math.Ceiling(count / (double)pageSize);
        Items = items;
    }

    public static PagedResult<T> Create(IReadOnlyList<T> items, int count, int pageNumber, int pageSize)
    {
        return new PagedResult<T>(items, count, pageNumber, pageSize);
    }
}
