using QUICK_INVENTORY.Domain;

namespace QUICK_INVENTORY.Data.Repositories.Application;

public interface IInventarioRepository
{
    Task<InventarioCorte?> ConsultarInventarioCorteActual();
}
