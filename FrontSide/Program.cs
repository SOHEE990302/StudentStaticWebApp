using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using FrontSide;
using System.Net.Http;
using System;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Ensure the correct API URL
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:7071/api/") });

// Register StudentService
builder.Services.AddScoped<StudentService>();

await builder.Build().RunAsync();
