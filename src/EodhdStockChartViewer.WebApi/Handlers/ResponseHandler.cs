using EodhdStockChartViewer.WebAPI.Constants;
using EodhdStockChartViewer.WebAPI.Helpers;
using System.Text.Json;

namespace EodhdStockChartViewer.WebAPI.Handlers;

public static class ResponseHandler
{
    public static async Task<Result<T>> HandleJson<T>(HttpResponseMessage response) where T : class
    {
        var content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            string errorMessage = string.IsNullOrWhiteSpace(content)
                ? Errors.UnexpectedApiError
                : content.Trim();

            return Result<T>.Fail(errorMessage, (int)response.StatusCode);
        }

        try
        {
            T? data = JsonSerializer.Deserialize<T>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return data is not null
                ? Result<T>.Success(data)
                : Result<T>.Fail(Errors.NullDeserialization, (int)response.StatusCode);
        }
        catch (JsonException ex)
        {
            return Result<T>.Fail($"{Errors.JsonParseError} {ex.Message}", (int)response.StatusCode);
        }
    }
}
