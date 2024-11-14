using QUICK_INVENTORY.Data.Repositories;
using QUICK_INVENTORY.Data.Services.Application;
using QUICK_INVENTORY.Domain;

namespace QUICK_INVENTORY.Helpers.Services.Application;

public class InventarioService(IApplicationRepositories repositories) : IInventarioService
{
    private readonly IApplicationRepositories _repositories = repositories;
}
