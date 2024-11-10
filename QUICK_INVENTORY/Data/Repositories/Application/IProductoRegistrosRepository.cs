using QUICK_INVENTORY.Shared.Models.Requests;

namespace QUICK_INVENTORY.Data.Repositories.Application;

public interface IProductoRegistrosRepository
{
    Task<int> ConsultarFolio(ProductoMovimientoCreateRequest createRequest);
}
