namespace EodhdStockChartViewer.WebAPI.Dtos;

/// <summary>
/// API response wrapper for a collection of historical prices
/// </summary>
/// <param name="Data">List of adjusted price entries</param>
public sealed record PriceChartResponse(List<PriceChartDto> Data);