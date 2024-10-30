using Microsoft.EntityFrameworkCore;
using QUICK_INVENTORY.Server.Data;
using QUICK_INVENTORY.Server.Data.Repositories;
using QUICK_INVENTORY.Server.Data.Repositories.Application;
using QUICK_INVENTORY.Shared.Models.Requests;

namespace QUICK_INVENTORY.Server.Helpers.Repositories.Application;

public class ProductoRegistrosRepository(IGeneralRepository generalRepository) : IProductoRegistrosRepository
{
    private readonly ApplicationDbContext _context = generalRepository.Context;

    public async Task<int> ConsultarFolio(ProductoRegistroCreateRequest request)
    {
        return (await _context.ProductoRegistros
            .Where(model => !model.EstaEliminado)
            .Where(model => model.RegistroTipoId == request.RegistroTipoId)
            .Select(model => model.Folio)
            .FirstOrDefaultAsync()) + 1;
    }
}
