using Blazored.LocalStorage;
using KanesKitchenClient;
using KanesKitchenClient.Services;
using KanesKitchenClient.Services.Implementations;
using KanesKitchenClient.Services.Interfaces;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddAuthorizationCore();
builder.Services.AddBlazoredLocalStorage();

builder.Services.AddTransient<CustomHttpHandler>();
builder.Services.AddHttpClient("ApiClient",
    client => client.BaseAddress = new Uri("https://localhost:7047")).AddHttpMessageHandler<CustomHttpHandler>();
//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7047") });
builder.Services.AddScoped<LocalStorageService>();
builder.Services.AddScoped<GetHttpClient>();
builder.Services.AddScoped<Session>();
builder.Services.AddScoped<LocalStorageService>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
builder.Services.AddScoped<IUserManagmentService, UserManagmentService>();

await builder.Build().RunAsync();
