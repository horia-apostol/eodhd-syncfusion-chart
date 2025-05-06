using EodhdStockChartViewer.WebAPI.Services;
using EodhdStockChartViewer.WebAPI.Settings;
using EodhdStockChartViewer.WebAPI.Mappers.Interfaces;
using EodhdStockChartViewer.WebAPI.Mappers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.Configure<EodhdSettings>(builder.Configuration.GetSection("EodhdSettings"));
builder.Services.AddScoped<IPriceMapper, PriceMapper>();

builder.Services.AddHttpClient<EodhdService>(client =>
{
    client.BaseAddress = new Uri("https://eodhd.com/api/");
});

builder.Services.AddSwaggerGen(options =>
{
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "EodhdStockChartViewer.WebApi.xml"));
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
