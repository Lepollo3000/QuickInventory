namespace QUICK_INVENTORY.Server.Data.Repositories;

public interface IGeneralRepository
{
    public ApplicationDbContext Context { get; }

    public void Add<T>(T entity) where T : class;
    public void AddRange<T>(List<T> entity) where T : class;
    public Task SaveAllAsync();
}
