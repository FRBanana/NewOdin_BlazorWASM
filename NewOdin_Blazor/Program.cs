using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using NewOdin_Blazor;
using NewOdin_Blazor.ViewModels;
using NewOdin_Blazor.Services;
using System;
using System.Net.Http;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
// Set the base address to the root URL of your API
builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("https://192.168.211.48:9095/")
});

// Register the needed Files
builder.Services.AddScoped<GanttViewModel>();
builder.Services.AddScoped<GanttDataService>();

await builder.Build().RunAsync();
