using EodhdStockChartViewer.WebAPI.Dtos;

namespace EodhdStockChartViewer.WebAPI.Mappers.Interfaces;

public interface IPriceMapper
{
    List<PriceChartDto> MapToChartData(List<PriceExternalDto> externalPrices);
}
