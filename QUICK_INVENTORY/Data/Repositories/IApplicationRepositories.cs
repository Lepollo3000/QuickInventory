using QUICK_INVENTORY.Data.Repositories.Application;

namespace QUICK_INVENTORY.Data.Repositories;

public interface IApplicationRepositories
{
    public IGeneralRepository General { get; }
    public IProductoRepository Productos { get; }
    public IInventarioRepository Inventario { get; }
    public IProductoMovimientosRepository ProductoRegistros { get; }
}
