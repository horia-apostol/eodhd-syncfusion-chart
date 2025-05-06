using EodhdStockChartViewer.WebAPI.Dtos;
using EodhdStockChartViewer.WebAPI.Mappers.Interfaces;

namespace EodhdStockChartViewer.WebAPI.Mappers;

public sealed class PriceMapper : IPriceMapper
{
    public List<PriceChartDto> MapToChartData(List<PriceExternalDto> externalPrices)
    {
        return [.. externalPrices
            .Where(p => p.Date != null && p.Close is > 0 && p.AdjustedClose is not null)
            .Select(p =>
            {
                var factor = p.AdjustedClose!.Value / p.Close!.Value;

                return new PriceChartDto(
                    Date: DateTime.Parse(p.Date!),
                    Open: p.Open.GetValueOrDefault() * factor,
                    High: p.High.GetValueOrDefault() * factor,
                    Low: p.Low.GetValueOrDefault() * factor,
                    Close: p.AdjustedClose.Value,
                    Volume: p.Volume ?? 0
                );
            })];
    }
}
