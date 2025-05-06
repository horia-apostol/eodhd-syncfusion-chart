using EodhdStockChartViewer.WebAPI.Constants;

namespace EodhdStockChartViewer.WebAPI.Helpers;

public static class UrlslHelper
{
    public static Uri BuildUri(
        string baseUrl,
        string symbol,
        Dictionary<string, string?> queryParams)
    {
        Uri baseUri = new(baseUrl);

        UriBuilder uriBuilder = new(baseUri)
        {
            Path = $"{baseUri.AbsolutePath}/{Defaults.Eod}/{symbol}",
            Query = QueriesHelper.BuildQuery(queryParams)
        };

        return uriBuilder.Uri;
    }
}
