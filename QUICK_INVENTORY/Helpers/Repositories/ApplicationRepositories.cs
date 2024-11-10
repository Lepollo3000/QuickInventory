using QUICK_INVENTORY.Data.Repositories;
using QUICK_INVENTORY.Data.Repositories.Application;

namespace QUICK_INVENTORY.Helpers.Repositories;

public class ApplicationRepositories(IGeneralRepository general, IProductoRegistrosRepository productoRegistros) : IApplicationRepositories
{
    public IGeneralRepository General { get => general; }
    public IProductoRegistrosRepository ProductoRegistros { get => productoRegistros; }
}
