using EodhdStockChartViewer.WebUI.Components;
using EodhdStockChartViewer.WebUI.Services;
using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddSyncfusionBlazor();
builder.Services.AddHttpClient<ChartDataService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7062");
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Your Syncfusion License");

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
