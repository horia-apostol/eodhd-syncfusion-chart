namespace EodhdStockChartViewer.WebUI.Models;

// Intentional lowercases to ensure proper data binding with Syncfusion Stock Chart component
public sealed record ChartData(
    DateTime date,
    decimal open,
    decimal high,
    decimal low,
    decimal close,
    long volume
);

