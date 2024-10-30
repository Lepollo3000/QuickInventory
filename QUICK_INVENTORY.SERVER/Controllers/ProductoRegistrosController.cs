using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QUICK_INVENTORY.Server.Data.Repositories;
using QUICK_INVENTORY.Server.Data.Services;
using QUICK_INVENTORY.Server.Domain;
using QUICK_INVENTORY.Shared.Helpers;
using QUICK_INVENTORY.Shared.Models.Requests;

namespace QUICK_INVENTORY.Server.Controllers;

[Authorize]
[ApiController]
[Route(ApplicationApis.ProductoRegistros)]
public class ProductoRegistrosController(IApplicationServices services, IApplicationRepositories repositories) : ControllerBase
{
    private readonly IApplicationServices _services = services;
    private readonly IApplicationRepositories _repositories = repositories;

    [HttpPost]
    public async Task<IActionResult> InsertarProductoRegistro([FromBody] ProductoRegistroCreateRequest createRequest)
    {
        IdentidadUsuario usuario = await _services
            .GeneralService.ConsultarUsuario(User);

        ProductoRegistro productoRegistro = await _services
            .ProductoRegistros.InsertarProductoRegistro(
                createRequest: createRequest,
                usuario: usuario);

        await _repositories.General.SaveAllAsync();

        return Ok(createRequest);
    }
}
