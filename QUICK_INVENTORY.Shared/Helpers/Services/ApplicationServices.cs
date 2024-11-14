using QUICK_INVENTORY.Client.Data.Services.Application;
using QUICK_INVENTORY.Shared.Helpers.Interfaces.Services;
using QUICK_INVENTORY.Shared.Helpers.Interfaces.Services.Application;

namespace QUICK_INVENTORY.Shared.Helpers.Services;

internal class ApplicationServices(IProductosService productos, IInventarioService inventarioCortes, IProductoMovimientosService productoRegistros) : IApplicationServices
{
    public IProductosService Productos { get => productos; }
    public IInventarioService InventarioCortes { get => inventarioCortes; }
    public IProductoMovimientosService ProductoMovimientos { get => productoRegistros; }
}
