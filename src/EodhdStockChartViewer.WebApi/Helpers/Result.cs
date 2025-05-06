namespace EodhdStockChartViewer.WebAPI.Helpers;

public sealed class Result<T>
{
    public bool IsSuccess { get; init; }
    public T? Value { get; init; }
    public string? Error { get; init; }
    public int? StatusCode { get; init; }
    public static Result<T> Success(T value) => new() { IsSuccess = true, Value = value };
    public static Result<T> Fail(string error, int? statusCode = null) => new() { IsSuccess = false, Error = error, StatusCode = statusCode };
}

