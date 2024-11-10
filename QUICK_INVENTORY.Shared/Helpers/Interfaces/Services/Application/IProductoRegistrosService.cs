using Ardalis.Result;
using QUICK_INVENTORY.Shared.Models.Requests;

namespace QUICK_INVENTORY.Shared.Helpers.Interfaces.Services.Application;

public interface IProductoRegistrosService
{
    Task<Result<ProductoMovimientoCreateRequest>> InsertarProductoRegistro(ProductoMovimientoCreateRequest createRequest);
}
