using QUICK_INVENTORY.Client.Data.Services.Application;
using QUICK_INVENTORY.Shared.Helpers.Interfaces.Services.Application;

namespace QUICK_INVENTORY.Shared.Helpers.Interfaces.Services;

public interface IApplicationServices
{
    IProductosService Productos { get; }
    IInventarioService InventarioCortes { get; }
    IProductoMovimientosService ProductoMovimientos { get; }
}
