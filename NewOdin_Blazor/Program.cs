using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using NewOdin_Blazor;
using NewOdin_Blazor.Services;
using NewOdin_Blazor.Services.Base;
using NewOdin_Blazor.ViewModels;
using System.Net.Http.Json;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var httpClient = new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) };
builder.Services.AddScoped(sp => httpClient);

var apiConfig = await httpClient.GetFromJsonAsync<ApiConfig>("apiconfig.json");
if (apiConfig is not null)
{
    builder.Services.AddSingleton(apiConfig);
}

// Register services
builder.Services.AddScoped<GanttService>();

// Register viewmodels
builder.Services.AddScoped<GanttViewModel>();

await builder.Build().RunAsync();
