namespace EodhdStockChartViewer.WebUI.Misc;

public static class Routes
{
    public const string Home = "/";
    public static string Prices(string symbol) => $"api/prices/{symbol}";
}
