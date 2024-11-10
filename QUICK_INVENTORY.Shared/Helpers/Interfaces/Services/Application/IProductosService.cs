using Ardalis.Result;
using QUICK_INVENTORY.Shared.Models.Requests;
using QUICK_INVENTORY.Shared.Models.TableModels;

namespace QUICK_INVENTORY.Client.Data.Services.Application;

public interface IProductosService
{
    Task<Result<ProductoTableModel>> ConsultarProducto(ProductoSearchRequest request);
    Task<Result<IEnumerable<ProductoTableModel>>> ConsultarProductos();
    Task<Result<ProductoTableModel>> InsertarProducto(ProductoCreateRequest request);
}
