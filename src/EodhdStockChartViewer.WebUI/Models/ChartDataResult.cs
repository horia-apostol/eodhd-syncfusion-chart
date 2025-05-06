namespace EodhdStockChartViewer.WebUI.Models;

public sealed record ChartDataResult(List<ChartData> Data, string? Error = null);