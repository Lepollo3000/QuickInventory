using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;
using QUICK_INVENTORY.Client.Data.Services.Application;
using QUICK_INVENTORY.Client.Helpers.Services;
using QUICK_INVENTORY.Shared.Helpers.Interfaces.Services;
using QUICK_INVENTORY.Shared.Helpers.Interfaces.Services.Application;
using QUICK_INVENTORY.Shared.Helpers.Services;
using QUICK_INVENTORY.Shared.Helpers.Services.Application;

namespace QUICK_INVENTORY.Shared.Helpers;

public static class ApplicationClientDependenciesExtension
{
    public static IServiceCollection AddApplicationClientDependencies(this IServiceCollection services)
    {
        services.AddHttpClient();

        services.AddScoped<IGeneralService, GeneralService>();
        services.AddScoped<IProductosService, ProductosService>();
        services.AddScoped<IInventarioService, InventarioService>();
        services.AddScoped<IProductoMovimientosService, ProductosMovimientosService>();

        services.AddScoped<IApplicationServices, ApplicationServices>();

        services.AddMudServices();
        services.AddSweetAlert2();

        return services;
    }
}
