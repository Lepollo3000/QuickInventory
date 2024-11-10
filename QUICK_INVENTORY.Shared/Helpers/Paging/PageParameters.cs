namespace QUICK_INVENTORY.Shared.Helpers.Paging;

public class PageParameters
{
    public const int MaxPageSize = 50;
    public const int DefaultPageSize = 10;
    public const int DefaultPageNumber = 1;

    private int _pageSize = DefaultPageSize;
    private int _pageNumber = DefaultPageNumber;

    public int PageSize
    {
        get => _pageSize;
        set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
    }
    public int PageNumber
    {
        get => _pageNumber;
        set => _pageNumber = (value < DefaultPageNumber) ? DefaultPageNumber : value;
    }
}
