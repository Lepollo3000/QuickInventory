using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QUICK_INVENTORY.Data.Repositories;
using QUICK_INVENTORY.Data.Services;
using QUICK_INVENTORY.Domain;
using QUICK_INVENTORY.Shared.Helpers;
using QUICK_INVENTORY.Shared.Models.Requests;
using QUICK_INVENTORY.Shared.Models.TableModels;

namespace QUICK_INVENTORY.Controllers;

[Authorize]
[ApiController]
[Route(ApplicationApiEndpoints.Productos.Principal)]
public class ProductosController(IApplicationServices services, IApplicationRepositories repositories) : ControllerBase
{
    private readonly IApplicationServices _services = services;
    private readonly IApplicationRepositories _repositories = repositories;

    [HttpGet]
    public async Task<IActionResult> ObtenerProducto([FromQuery] ProductoSearchRequest request)
    {
        try
        {
            var tableModel = await _services
                .Productos.ConsultarProducto(request);

            return Ok(tableModel);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpGet("listado")]
    public async Task<IActionResult> ObtenerProductos()
    {
        try
        {
            var tableModelList = await _services
                .Productos.ConsultarProductos();

            return Ok(tableModelList);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> InsertarProducto([FromBody] ProductoCreateRequest request)
    {
        try
        {
            IdentidadUsuario usuario = await _services
                .GeneralService.ConsultarUsuario(User);

            Producto producto = await _services
                .Productos.InsertarProducto(
                    request: request,
                    usuario: usuario);

            await _repositories.General.Context.SaveChangesAsync();

            ProductoTableModel tableModel = new()
            {
                CodigoBarras = producto.CodigoBarras,
                Locacion = producto.Locacion,
                Nombre = producto.Nombre,
                Descripcion = producto.Descripcion,
                StockMedidaId = producto.StockMedidaId,
                StockMinimo = producto.StockMinimo,
                StockMaximo = producto.StockMaximo,
                Stock = producto.Stock
            };

            return Ok(tableModel);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}
