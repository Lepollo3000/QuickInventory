using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QUICK_INVENTORY.Data.Repositories;
using QUICK_INVENTORY.Data.Services;
using QUICK_INVENTORY.Shared.Helpers;
using QUICK_INVENTORY.Shared.Models;
using QUICK_INVENTORY.Shared.Models.TableModels;

namespace QUICK_INVENTORY.Controllers;

[Authorize]
[ApiController]
[Route(ApplicationApiEndpoints.Inventario.Cortes.Principal)]
public class InventarioController(IApplicationServices services, IApplicationRepositories repositories) : ControllerBase
{
    private readonly IApplicationServices _services = services;
    private readonly IApplicationRepositories _repositories = repositories;

    [HttpGet("actual")]
    public async Task<IActionResult> ObtenerInventario()
    {
        try
        {
            var tableModelList = await _repositories.General.Context.InventarioCortes
                .Include(model => model.Detalles)
                    .ThenInclude(model => model.Producto)
                        .ThenInclude(model => model.StockMedida)
                .Include(model => model.Detalles)
                    .ThenInclude(model => model.Producto)
                        .ThenInclude(model => model.Movimientos)
                .Where(model => !model.EstaEliminado)
                .Where(model => model.FechaFin == null)
                .SelectMany(model => model.Detalles
                    .Where(model => !model.EstaEliminado)
                    .Where(model => !model.Producto.EstaEliminado)
                    .Select(detalle => new InventarioDetalleTableModel
                    {
                        Id = detalle.Producto.Id,
                        CodigoBarras = detalle.Producto.CodigoBarras,
                        Locacion = detalle.Producto.Locacion,
                        Nombre = detalle.Producto.Nombre,
                        Descripcion = detalle.Producto.Descripcion,
                        StockMedidaId = detalle.Producto.StockMedidaId,
                        StockMedida = detalle.Producto.StockMedida.Descripcion,
                        StockMinimo = detalle.Producto.StockMinimo,
                        StockMaximo = detalle.Producto.StockMaximo,

                        StockInicial = detalle.StockInicial,
                        StockFinal = detalle.StockFinal
                            ?? detalle.Producto.Stock,
                        CantidadEntradas = detalle.Producto.Movimientos
                            .Where(movimiento => !movimiento.EstaEliminado)
                            .Where(movimiento => movimiento.MovimientoTipoId == EnumMovimientoTipo.Entrada)
                            .Where(movimiento => detalle.InventarioCorte.FechaInicio <= movimiento.FechaMovimiento)
                            .Where(movimiento => detalle.InventarioCorte.FechaFin == null
                                || detalle.InventarioCorte.FechaFin >= movimiento.FechaMovimiento)
                            .Count(),
                        CantidadSalidas = detalle.Producto.Movimientos
                            .Where(movimiento => !movimiento.EstaEliminado)
                            .Where(movimiento => movimiento.MovimientoTipoId == EnumMovimientoTipo.Salida)
                            .Where(movimiento => detalle.InventarioCorte.FechaInicio <= movimiento.FechaMovimiento)
                            .Where(movimiento => detalle.InventarioCorte.FechaFin == null
                                || detalle.InventarioCorte.FechaFin >= movimiento.FechaMovimiento)
                            .Count()
                    })
                    .ToList())
                .ToListAsync();

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
}
