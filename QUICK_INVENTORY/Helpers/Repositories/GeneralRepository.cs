using QUICK_INVENTORY.Data;
using QUICK_INVENTORY.Data.Repositories;

namespace QUICK_INVENTORY.Helpers.Repositories;

public class GeneralRepository(ApplicationDbContext context) : IGeneralRepository
{
    public ApplicationDbContext Context { get => context; }
}
