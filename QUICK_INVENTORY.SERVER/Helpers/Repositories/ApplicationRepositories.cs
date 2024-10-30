using QUICK_INVENTORY.Server.Data.Repositories;
using QUICK_INVENTORY.Server.Data.Repositories.Application;

namespace QUICK_INVENTORY.Server.Helpers.Repositories;

public class ApplicationRepositories(IGeneralRepository general, IProductoRegistrosRepository productoRegistros) : IApplicationRepositories
{
    public IGeneralRepository General { get => general; }
    public IProductoRegistrosRepository ProductoRegistros { get => productoRegistros; }
}
