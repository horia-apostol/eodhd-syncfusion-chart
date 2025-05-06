using Microsoft.AspNetCore.Mvc;

namespace EodhdStockChartViewer.WebAPI.Dtos;

/// <param name="From"> Optional start date (format: yyyy-MM-dd) </param>
/// <param name="To"> Optional end date (format: yyyy-MM-dd) </param>
/// <param name="Period"> Optional period for the data (daily, weekly, monthly) </param>
/// <param name="Order"> Optional order of the data (ascending or descending) </param>
public sealed record PriceQueryDto(
    [property: FromQuery(Name = "from")] DateOnly? From, 
    [property: FromQuery(Name = "to")] DateOnly? To,
    [property: FromQuery(Name = "period")] string? Period,
    [property: FromQuery(Name = "order")] string? Order
);