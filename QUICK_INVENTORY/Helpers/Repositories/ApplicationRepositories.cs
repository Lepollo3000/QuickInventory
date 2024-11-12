using QUICK_INVENTORY.Data.Repositories;
using QUICK_INVENTORY.Data.Repositories.Application;

namespace QUICK_INVENTORY.Helpers.Repositories;

public class ApplicationRepositories(IGeneralRepository general, IProductoRepository productos, IProductoRegistrosRepository productoRegistros) : IApplicationRepositories
{
    public IGeneralRepository General { get => general; }
    public IProductoRepository Productos { get => productos; }
    public IProductoRegistrosRepository ProductoRegistros { get => productoRegistros; }
}
