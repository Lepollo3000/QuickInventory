using Ardalis.Result;
using QUICK_INVENTORY.Shared.Models.Requests;

namespace QUICK_INVENTORY.Client.Data.Services.Application;

public interface IProductoRegistrosService
{
    Task<Result<ProductoRegistroCreateRequest>> InsertarProductoRegistro(ProductoRegistroCreateRequest createRequest);
}
