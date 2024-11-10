namespace QUICK_INVENTORY.Shared.Helpers;

public static class QueryStringHelpers
{
    public static string BuildUrlWithQueryStringUsingStringConcat(this string basePath, Dictionary<string, string> queryParams)
    {
        var uriBuilder = new UriBuilder(basePath)
        {
            Query = string.Join("&", queryParams.Select(value => $"{value.Key}={value.Value}"))
        };

        return uriBuilder.Uri.AbsoluteUri;
    }
}
