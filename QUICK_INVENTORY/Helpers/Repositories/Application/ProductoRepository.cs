using Microsoft.EntityFrameworkCore;
using QUICK_INVENTORY.Data;
using QUICK_INVENTORY.Data.Repositories;
using QUICK_INVENTORY.Data.Repositories.Application;
using QUICK_INVENTORY.Domain;

namespace QUICK_INVENTORY.Helpers.Repositories.Application;

public class ProductoRepository(IGeneralRepository generalRepository) : IProductoRepository
{
    private readonly ApplicationDbContext _context = generalRepository.Context;

    public async Task<Producto?> ConsultarProducto(int productoId)
    {
        return await _context.Productos
            .Where(model => !model.EstaEliminado)
            .Where(model => model.Id == productoId)
            .FirstOrDefaultAsync();
    }
}
