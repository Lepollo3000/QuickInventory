﻿namespace QUICK_INVENTORY.Shared.Helpers.Paging;

public class OrderTerm { }

public class SearchTerm { }

public class SearchParameters<TOrder, TSearch>(TOrder order, TSearch search, PageParameters pageParameters)
where TOrder : OrderTerm
where TSearch : SearchTerm
{
    public TOrder OrderTerm { get; set; } = order;
    public TSearch SearchTerm { get; set; } = search;
    public PageParameters PageParameters { get; set; } = pageParameters;
}
