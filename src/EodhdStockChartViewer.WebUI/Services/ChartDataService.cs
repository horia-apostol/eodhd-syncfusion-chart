using EodhdStockChartViewer.WebUI.Misc;
using EodhdStockChartViewer.WebUI.Models;

namespace EodhdStockChartViewer.WebUI.Services;

public sealed class ChartDataService(HttpClient httpClient)
{
    private readonly HttpClient _http = httpClient;

    public async Task<ChartDataResult> LoadChartDataAsync(string symbol)
    {
        try
        {
            var response = await _http.GetFromJsonAsync<PriceResponse>(Routes.Prices(symbol));

            if (response is null || response.Data.Count == 0)
            {
                return new ChartDataResult([], Errors.NoDataFound);
            }
                
            return new ChartDataResult(response.Data, null);
        }
        catch (Exception ex)
        {
            return new ChartDataResult([], Errors.FailedToLoadChart(ex.Message));
        }
    }
}
