using Microsoft.EntityFrameworkCore;
using QUICK_INVENTORY.Data;
using QUICK_INVENTORY.Data.Repositories;
using QUICK_INVENTORY.Data.Repositories.Application;
using QUICK_INVENTORY.Shared.Models.Requests;

namespace QUICK_INVENTORY.Helpers.Repositories.Application;

public class ProductoRegistrosRepository(IGeneralRepository generalRepository) : IProductoRegistrosRepository
{
    private readonly ApplicationDbContext _context = generalRepository.Context;

    public async Task<int> ConsultarFolio(ProductoMovimientoCreateRequest request)
    {
        return (await _context.ProductoRegistros
            .Where(model => !model.EstaEliminado)
            .Where(model => model.RegistroTipoId == request.RegistroTipoId)
            .Select(model => model.Folio)
            .FirstOrDefaultAsync()) + 1;
    }
}
