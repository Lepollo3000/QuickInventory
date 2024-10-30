using QUICK_INVENTORY.Server.Data.Repositories.Application;

namespace QUICK_INVENTORY.Server.Data.Repositories;

public interface IApplicationRepositories
{
    public IGeneralRepository General { get; }
    public IProductoRegistrosRepository ProductoRegistros { get; }
}
