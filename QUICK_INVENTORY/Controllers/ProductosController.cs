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
    public async Task<IActionResult> ObtenerProductos([FromQuery] ProductoSearchRequest searchRequest)
    {
        try
        {
            var tableModelList = await _services
                .Productos.ConsultarProductos(
                    searchRequest: searchRequest);

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

            InventarioCorte? corteActual = await _repositories
                .Inventario.ConsultarInventarioCorteActual();

            if (corteActual == null)
            {
                corteActual = new(usuario: usuario);

                _repositories.General.Context.Add(corteActual);
            }

            InventarioCorteDetalle corteDetalle = new(
                producto: producto,
                corte: corteActual,
                usuario: usuario);

            _repositories.General.Context.Add(corteDetalle);

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
