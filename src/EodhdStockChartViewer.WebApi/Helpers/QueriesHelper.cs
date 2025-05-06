using System.Web;

namespace EodhdStockChartViewer.WebAPI.Helpers;

public static class QueriesHelper
{
    public static string BuildQuery(Dictionary<string, string?> values)
    {
        var query = HttpUtility.ParseQueryString(string.Empty);
        foreach (var kvp in values)
        {
            if (!string.IsNullOrWhiteSpace(kvp.Value))
            {
                query[kvp.Key] = kvp.Value;
            }
                
        }

        return query.ToString()!;
    }
}
