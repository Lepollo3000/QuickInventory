using QUICK_INVENTORY.Server.Data;
using QUICK_INVENTORY.Server.Data.Repositories;

namespace QUICK_INVENTORY.Server.Helpers.Repositories;

public class GeneralRepository(ApplicationDbContext context) : IGeneralRepository
{
    public ApplicationDbContext Context { get => context; }

    public void Add<T>(T entity) where T : class
    {
        Context.Add(entity);
    }

    public void AddRange<T>(List<T> entity) where T : class
    {
        Context.AddRange(entity);
    }

    public async Task SaveAllAsync()
    {
        try
        {
            await Context.SaveChangesAsync();
        }
        catch (Exception)
        {
            throw new InvalidOperationException("Lo sentimos, ocurrió un error inesperado. Intente de nuevo más tarde o consulte con un administrador.");
        }
    }
}
