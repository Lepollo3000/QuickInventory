using QUICK_INVENTORY.Server.Domain;
using QUICK_INVENTORY.Shared.Models.Requests;

namespace QUICK_INVENTORY.Server.Data.Services.Application;

public interface IProductoRegistrosService
{
    Task<ProductoRegistro> InsertarProductoRegistro(ProductoRegistroCreateRequest createRequest, IdentidadUsuario usuario);
}
