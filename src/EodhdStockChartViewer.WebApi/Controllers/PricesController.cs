using EodhdStockChartViewer.WebAPI.Dtos;
using EodhdStockChartViewer.WebAPI.Services;
using EodhdStockChartViewer.WebAPI.Mappers.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using EodhdStockChartViewer.WebAPI.Constants;
using EodhdStockChartViewer.WebAPI.Helpers;

namespace EodhdStockChartViewer.WebAPI.Controllers;

/// <summary>
/// Provides historical end-of-day stock data using the EODHD API
/// </summary>
[ApiController]
[Route("api/prices")]
public sealed class PricesController(EodhdService service, IPriceMapper mapper) : ControllerBase
{
    private readonly EodhdService _service = service;
    private readonly IPriceMapper _mapper = mapper;

    /// <summary>
    /// Retrieves historical stock prices for a specific symbol
    /// </summary>
    /// <param name="symbol">The stock ticker symbol (e.g. AAPL)</param>
    /// <param name="query">Optional parameters: period, order, from, to</param>
    /// <returns>A list of stock splits adjusted historical prices</returns>
    /// <response code="200">Returns the price history in JSON format</response>
    /// <response code="400">The symbol is malformed</response>
    /// <response code="401">The API token is missing or invalid</response>
    /// <response code="403">Access to the resource is forbidden with the provided API key</response>
    /// <response code="500">Internal server errror</response>
    [HttpGet("{symbol}")]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(PriceChartResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string),StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(string),StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(string),StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(string),StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Get(string symbol, [FromQuery] PriceQueryDto query)
    {
        Result<List<PriceExternalDto>> result = await _service.GetPriceDataAsync(
            symbol,
            query.Period,
            query.Order,
            query.From?.ToString(Formats.Date.Iso8601),
            query.To?.ToString(Formats.Date.Iso8601)
        );

        if (!result.IsSuccess)
        {
            return result.StatusCode switch
            {
                400 => BadRequest(result.Error),
                401 => StatusCode(StatusCodes.Status401Unauthorized, result.Error),
                403 => StatusCode(StatusCodes.Status403Forbidden, result.Error),
                404 => NotFound(result.Error),
                500 => StatusCode(StatusCodes.Status500InternalServerError, result.Error),
                _ => BadRequest(result.Error)
            };
        }

        List<PriceChartDto> items = _mapper.MapToChartData(result.Value!);
        return Ok(new PriceChartResponse(items));
    }
}
