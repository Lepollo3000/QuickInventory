using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

    [HttpGet("warnings/{productoId}")]
    public async Task<IActionResult> WarningsProducto(int productoId)
    {
        try
        {
            Producto producto = await _repositories.General.Context.Productos
                .Where(model => !model.EstaEliminado)
                .Where(model => model.Id == productoId)
                .FirstOrDefaultAsync()
                ?? throw new ArgumentException("El producto ingresado no se encontró o no existe.");

            if (producto.Stock <= producto.StockMinimo)
            {
                return BadRequest($"El producto ha alcanzado su nivel de stock mínimo, se recomienda ordenar más de éste.");
            }
            else if(producto.Stock >= producto.StockMaximo)
            {
                return BadRequest($"El producto ha alcanzado su nivel de stock máximo, no se recomienda ordenar más de éste.");
            }

            return NoContent();
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
