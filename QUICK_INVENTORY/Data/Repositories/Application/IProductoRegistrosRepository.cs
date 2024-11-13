using QUICK_INVENTORY.Shared.Models.Requests;
using QUICK_INVENTORY.Shared.Models.TableModels;

namespace QUICK_INVENTORY.Data.Repositories.Application;

public interface IProductoRegistrosRepository
{
    Task<int> ConsultarFolio(ProductoMovimientoCreateRequest createRequest);
    Task<IEnumerable<ProductoMovimientoTableModel>> ConsultarMovimientos(ProductoMovimientoSearchRequest search);
}
