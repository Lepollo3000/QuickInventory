using QUICK_INVENTORY.Data.Repositories;
using QUICK_INVENTORY.Data.Repositories.Application;

namespace QUICK_INVENTORY.Helpers.Repositories;

public class ApplicationRepositories(IGeneralRepository general, IProductoRepository productos, IInventarioRepository inventario, IProductoMovimientosRepository productoRegistros) : IApplicationRepositories
{
    public IGeneralRepository General { get => general; }
    public IProductoRepository Productos { get => productos; }
    public IInventarioRepository Inventario { get => inventario; }
    public IProductoMovimientosRepository ProductoRegistros { get => productoRegistros; }
}
