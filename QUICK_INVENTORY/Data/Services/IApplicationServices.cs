using QUICK_INVENTORY.Data.Services.Application;

namespace QUICK_INVENTORY.Data.Services;

public interface IApplicationServices
{
    IGeneralService GeneralService { get; }
    IProductosService Productos { get; }
    IInventarioService Inventario { get; }
    IProductoMovimientosService ProductoMovimientos { get; }
}
