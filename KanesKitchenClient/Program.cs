using Blazored.LocalStorage;
using KanesKitchenClient;
using System.Globalization;
using Microsoft.JSInterop;
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
builder.Services.AddScoped<IImageService, ImageService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IBasketService, BasketService>();
builder.Services.AddLocalization();

var host = builder.Build();

const string defaultCulture = "en-Uk";

var js = host.Services.GetRequiredService<IJSRuntime>();

var result = await js.InvokeAsync<string>("blazorCulture.get");
var culture = CultureInfo.GetCultureInfo(result ?? defaultCulture);

if (result == null)
{
    await js.InvokeVoidAsync("blazorCulture.set", defaultCulture);
}

CultureInfo.DefaultThreadCurrentCulture = culture;
CultureInfo.DefaultThreadCurrentUICulture = culture;

await host.RunAsync();
