using QUICK_INVENTORY.Shared.Models.Requests;

namespace QUICK_INVENTORY.Server.Data.Repositories.Application;

public interface IProductoRegistrosRepository
{
    Task<int> ConsultarFolio(ProductoRegistroCreateRequest createRequest);
}
