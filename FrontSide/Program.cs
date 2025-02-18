using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using FrontSide;
using System.Net.Http;
using System;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Azure 및 로컬 환경 감지
string apiBaseUrl;

if (builder.HostEnvironment.IsDevelopment()) // 로컬 실행 시
{
    apiBaseUrl = "http://localhost:7071/api/";
}
else // 배포된 환경에서는 Azure Static Web Apps API URL 사용
{
    apiBaseUrl = "https://purple-rock-0829d3d10.4.azurestaticapps.net/api/"; // 너의 Azure Static Web Apps 주소
}

// HttpClient 설정
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(apiBaseUrl) });

// StudentService 등록
builder.Services.AddScoped<StudentService>();

await builder.Build().RunAsync();
