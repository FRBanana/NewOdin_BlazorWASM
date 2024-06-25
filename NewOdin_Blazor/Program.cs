using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using NewOdin_Blazor;
using NewOdin_Blazor.Services;
using NewOdin_Blazor.Services.API;
using NewOdin_Blazor.Services.Interfaces;
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

builder.Services.AddScoped<IGanttService, GanttService>();

await builder.Build().RunAsync();
