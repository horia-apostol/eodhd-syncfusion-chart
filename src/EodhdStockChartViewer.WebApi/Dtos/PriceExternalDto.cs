using System.Text.Json.Serialization;

namespace EodhdStockChartViewer.WebAPI.Dtos;

/// <summary>
/// Raw price data received from the EODHD API
/// </summary>
public sealed record PriceExternalDto(
    [property: JsonPropertyName("date")] string? Date,
    [property: JsonPropertyName("open")] decimal? Open,
    [property: JsonPropertyName("high")] decimal? High,
    [property: JsonPropertyName("low")] decimal? Low,
    [property: JsonPropertyName("close")] decimal? Close,
    [property: JsonPropertyName("adjusted_close")] decimal? AdjustedClose,
    [property: JsonPropertyName("volume")] long? Volume
);
