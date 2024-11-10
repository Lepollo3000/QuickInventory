using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using QUICK_INVENTORY.Client.Helpers;
using QUICK_INVENTORY.Shared.Helpers;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services
    .AddAuthorizationCore();
builder.Services
    .AddCascadingAuthenticationState();
builder.Services
    .AddSingleton<AuthenticationStateProvider, PersistentAuthenticationStateProvider>();

builder.Services
    .AddMudServices();

builder.Services
    .AddApplicationClientDependencies();

await builder.Build().RunAsync();
