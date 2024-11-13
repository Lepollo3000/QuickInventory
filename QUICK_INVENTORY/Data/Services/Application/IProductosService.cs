using QUICK_INVENTORY.Domain;
using QUICK_INVENTORY.Shared.Models.Requests;
using QUICK_INVENTORY.Shared.Models.TableModels;

namespace QUICK_INVENTORY.Data.Services.Application;

public interface IProductosService
{
    Task<ProductoTableModel?> ConsultarProducto(ProductoSearchRequest request);
    Task<IEnumerable<ProductoTableModel>> ConsultarProductos(ProductoSearchRequest searchRequest);
    Task<Producto> InsertarProducto(ProductoCreateRequest request, IdentidadUsuario usuario);
}
