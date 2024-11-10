using QUICK_INVENTORY.Data.Repositories.Application;

namespace QUICK_INVENTORY.Data.Repositories;

public interface IApplicationRepositories
{
    public IGeneralRepository General { get; }
    public IProductoRegistrosRepository ProductoRegistros { get; }
}
