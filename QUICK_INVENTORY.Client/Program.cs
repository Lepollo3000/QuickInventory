using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using QUICK_INVENTORY.Client;
using QUICK_INVENTORY.Client.Data.Services;
using QUICK_INVENTORY.Client.Data.Services.Application;
using QUICK_INVENTORY.Client.Helpers.Services;
using QUICK_INVENTORY.Client.Helpers.Services.Application;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");

builder.Services
    .AddHttpClient(
        name: "QUICK_INVENTORY.ServerAPI",
        configureClient: client =>
        {
            client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
        })
    .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

// Supply HttpClient instances that include access tokens when making requests to the server project
builder.Services
    .AddScoped(sp => sp
        .GetRequiredService<IHttpClientFactory>()
        .CreateClient("QUICK_INVENTORY.ServerAPI"));

builder.Services
    .AddApiAuthorization();

builder.Services.AddScoped<IGeneralService, GeneralService>();
builder.Services.AddScoped<IProductoRegistrosService, ProductosRegistrosService>();

builder.Services.AddScoped<IApplicationServices, ApplicationServices>();

await builder.Build().RunAsync();
