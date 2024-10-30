using QUICK_INVENTORY.Server.Data.Repositories;
using QUICK_INVENTORY.Server.Data.Services.Application;
using QUICK_INVENTORY.Server.Domain;
using QUICK_INVENTORY.Shared.Models.Requests;

namespace QUICK_INVENTORY.Server.Helpers.Services.Application;

public class ProductoRegistrosService(IApplicationRepositories repositories) : IProductoRegistrosService
{
    private readonly IApplicationRepositories _repositories = repositories;

    public async Task<ProductoRegistro> InsertarProductoRegistro(ProductoRegistroCreateRequest createRequest, IdentidadUsuario usuario)
    {
        int folio = await _repositories
            .ProductoRegistros.ConsultarFolio(
                createRequest: createRequest);

        var productoRegistro =
            new ProductoRegistro(
                createRequest: createRequest,
                folio: folio,
                usuario: usuario);

        _repositories.General.Add(productoRegistro);

        await Task.CompletedTask;

        return productoRegistro;
    }
}
