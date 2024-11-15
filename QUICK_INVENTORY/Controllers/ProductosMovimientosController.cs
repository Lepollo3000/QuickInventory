using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QUICK_INVENTORY.Data.Repositories;
using QUICK_INVENTORY.Data.Services;
using QUICK_INVENTORY.Domain;
using QUICK_INVENTORY.Shared.Helpers;
using QUICK_INVENTORY.Shared.Models;
using QUICK_INVENTORY.Shared.Models.Requests;

namespace QUICK_INVENTORY.Controllers;

[Authorize]
[ApiController]
[Route(ApplicationApiEndpoints.Productos.Movimientos.Principal)]
public class ProductosMovimientosController(IApplicationServices services, IApplicationRepositories repositories) : ControllerBase
{
    private readonly IApplicationServices _services = services;
    private readonly IApplicationRepositories _repositories = repositories;

    [HttpGet]
    public async Task<IActionResult> ObtenerProductoMovimientos([FromQuery] ProductoMovimientoSearchRequest search)
    {
        try
        {
            var tableModelList = await _repositories
                .ProductoRegistros.ConsultarMovimientos(search: search);

            return Ok(tableModelList);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> InsertarProductoRegistro([FromBody] ProductoMovimientoCreateRequest createRequest)
    {
        try
        {
            IdentidadUsuario usuario = await _services
                .GeneralService.ConsultarUsuario(User);

            Producto producto = await _repositories
                .Productos.ConsultarProducto(productoId: createRequest.ProductoId)
                ?? throw new ArgumentException("El producto ingresado no se encontró o no existe.");

            ProductoMovimiento productoRegistro = await _services
                .ProductoMovimientos.InsertarProductoRegistro(
                    createRequest: createRequest,
                    usuario: usuario);

            if (productoRegistro.MovimientoTipoId == EnumMovimientoTipo.Salida)
            {
                producto.Stock -= productoRegistro.MovimientoCantidad;
            }
            else if (productoRegistro.MovimientoTipoId == EnumMovimientoTipo.Entrada)
            {
                producto.Stock += productoRegistro.MovimientoCantidad;
            }

            await _repositories.General.Context.SaveChangesAsync();

            return Ok(createRequest);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}
