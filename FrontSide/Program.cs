using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using FrontSide;
using System.Net.Http;
using System;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

string apiBaseUrl;

if (builder.HostEnvironment.IsDevelopment())
{
    apiBaseUrl = "http://localhost:7071/api/";
}
else
{
    apiBaseUrl = "https://staticwebappsh.azurestaticapps.net/api/";
}

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(apiBaseUrl) });

builder.Services.AddScoped<StudentService>();

await builder.Build().RunAsync();
