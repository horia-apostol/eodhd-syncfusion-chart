using EodhdStockChartViewer.WebAPI.Constants;
using EodhdStockChartViewer.WebAPI.Dtos;
using EodhdStockChartViewer.WebAPI.Handlers;
using EodhdStockChartViewer.WebAPI.Helpers;
using EodhdStockChartViewer.WebAPI.Settings;
using Microsoft.Extensions.Options;

namespace EodhdStockChartViewer.WebAPI.Services;

public sealed class EodhdService(HttpClient httpClient, IOptions<EodhdSettings> options)
{
    private readonly HttpClient _httpClient = httpClient;
    private readonly string _token = options.Value.ApiToken!;
    private readonly string _baseUrl = options.Value.BaseUrl!;

    public async Task<Result<List<PriceExternalDto>>> GetPriceDataAsync(
        string symbol,
        string? period = PricePeriods.Daily,
        string? order = SortOrders.Ascending,
        string? from = null,
        string? to = null)
    {

        Dictionary<string, string?> queryParams = new Dictionary<string, string?>
        {
            [Defaults.ApiToken] = _token,
            [Defaults.Period] = period,
            [Defaults.Order] = order,
            [Defaults.Format] = Formats.Json,
            [Defaults.From] = from,
            [Defaults.To] = to
        };

        Uri url = UrlslHelper.BuildUri(_baseUrl, symbol, queryParams);
        var response = await _httpClient.GetAsync(url);
        return await ResponseHandler.HandleJson<List<PriceExternalDto>>(response);
    }
}
