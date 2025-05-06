namespace EodhdStockChartViewer.WebUI.Misc;

public static class Errors
{
    public const string NoDataFound = "No data found for this symbol.";
    public static string FailedToLoadChart(string error) => $"Failed to load chart: {error}";
}
