using Ardalis.Result;
using QUICK_INVENTORY.Shared.Models.Requests;
using QUICK_INVENTORY.Shared.Models.TableModels;

namespace QUICK_INVENTORY.Shared.Helpers.Interfaces.Services.Application;

public interface IProductoMovimientosService
{
    Task<Result<IEnumerable<ProductoMovimientoTableModel>>> ConsultarProductoMovimientos(ProductoMovimientoSearchRequest searchRequest);
    Task<Result<ProductoMovimientoCreateRequest>> InsertarProductoMovimiento(ProductoMovimientoCreateRequest createRequest);
}
