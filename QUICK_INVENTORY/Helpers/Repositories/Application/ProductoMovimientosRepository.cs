using Microsoft.EntityFrameworkCore;
using QUICK_INVENTORY.Data;
using QUICK_INVENTORY.Data.Repositories;
using QUICK_INVENTORY.Data.Repositories.Application;
using QUICK_INVENTORY.Shared.Models.Requests;
using QUICK_INVENTORY.Shared.Models.TableModels;

namespace QUICK_INVENTORY.Helpers.Repositories.Application;

public class ProductoMovimientosRepository(IGeneralRepository generalRepository) : IProductoMovimientosRepository
{
    private readonly ApplicationDbContext _context = generalRepository.Context;

    public async Task<int> ConsultarFolio(ProductoMovimientoCreateRequest request)
    {
        return (await _context.ProductoMovimientos
            .Where(model => model.MovimientoTipoId == request.MovimientoTipoId)
            .OrderByDescending(model => model.Folio)
            .Select(model => model.Folio)
            .FirstOrDefaultAsync()) + 1;
    }

    public async Task<IEnumerable<ProductoMovimientoTableModel>> ConsultarMovimientos(ProductoMovimientoSearchRequest search)
    {
        return await _context.ProductoMovimientos
            .Include(model => model.Producto)
            .Include(model => model.MovimientoTipo)
            .Where(model => !model.EstaEliminado)
            .Where(model => model.MovimientoTipoId == search.MovimientoTipoId)
            .Select(model => new ProductoMovimientoTableModel
            {
                Folio = model.Folio,
                Producto = model.Producto.Nombre,
                MovimientoCantidad = model.MovimientoCantidad,
                MovimientoTipoId = model.MovimientoTipoId,
                MovimientoTipo = model.MovimientoTipo.Descripcion,
                NumeroExterno = model.NumeroExterno,
                NumeroInterno = model.NumeroInterno
            })
            .ToListAsync();
    }
}
