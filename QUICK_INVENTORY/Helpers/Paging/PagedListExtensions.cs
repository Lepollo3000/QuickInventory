using Microsoft.EntityFrameworkCore;
using QUICK_INVENTORY.Shared.Helpers.Paging;
namespace QUICK_INVENTORY.Helpers.Paging;

public static class PagedListExtensions
{
    public static PagedList<T> ToPagedList<T>(this IEnumerable<T> items, int totalCount, PageParameters pageParameters)
    {
        return new(items, totalCount, pageParameters.PageSize, pageParameters.PageNumber);
    }

    public static async Task<PagedList<T>> ToPagedListAsync<T>(this IQueryable<T> query, PageParameters pageParameters)
    {
        int totalCount = await query.CountAsync();

        var items = await query
            .Skip(pageParameters.PageNumber
                * pageParameters.PageSize)
            .Take(pageParameters.PageSize)
            .ToListAsync();

        return new(items, totalCount, pageParameters.PageSize, pageParameters.PageNumber);
    }
}
