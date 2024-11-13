using QUICK_INVENTORY.Client.Data.Services;
using QUICK_INVENTORY.Client.Data.Services.Application;
using QUICK_INVENTORY.Shared.Helpers.Interfaces.Services.Application;

namespace QUICK_INVENTORY.Client.Helpers.Services;

internal class ApplicationServices(IProductosService productos, IProductoMovimientosService productoRegistros) : IApplicationServices
{
    public IProductosService Productos { get => productos; }
    public IProductoMovimientosService ProductoMovimientos { get => productoRegistros; }
}
