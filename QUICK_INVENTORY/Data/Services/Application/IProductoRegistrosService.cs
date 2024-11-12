using QUICK_INVENTORY.Domain;
using QUICK_INVENTORY.Shared.Models.Requests;
using QUICK_INVENTORY.Shared.Models.TableModels;

namespace QUICK_INVENTORY.Data.Services.Application;

public interface IProductoRegistrosService
{
    Task<ProductoMovimiento> InsertarProductoRegistro(ProductoMovimientoCreateRequest createRequest, IdentidadUsuario usuario);
    Task<IEnumerable<ProductoMovimientoTableModel>> ConsultarProductoRegistros();
}
