namespace EodhdStockChartViewer.WebAPI.Dtos;

/// <summary>
/// Parsed and adjusted price data
/// </summary>
/// <param name="Date"></param>
/// <param name="Open">Adjusted opening price</param>
/// <param name="High">Adjusted high price</param>
/// <param name="Low">Adjusted low price</param>
/// <param name="Close">Adjusted close price</param>
/// <param name="Volume"></param>
public sealed record PriceChartDto(
    DateTime Date,
    decimal Open,
    decimal High,
    decimal Low,
    decimal Close,
    long Volume
);
