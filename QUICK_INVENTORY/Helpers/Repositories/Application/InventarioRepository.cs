using Microsoft.EntityFrameworkCore;
using QUICK_INVENTORY.Data;
using QUICK_INVENTORY.Data.Repositories;
using QUICK_INVENTORY.Data.Repositories.Application;
using QUICK_INVENTORY.Domain;

namespace QUICK_INVENTORY.Helpers.Repositories.Application;

public class InventarioRepository(IGeneralRepository generalRepository) : IInventarioRepository
{
    private readonly ApplicationDbContext _context = generalRepository.Context;

    public async Task<InventarioCorte?> ConsultarInventarioCorteActual()
    {
        return await _context.InventarioCortes
            .Where(model => !model.EstaEliminado)
            .Where(model => model.FechaFin == null)
            .FirstOrDefaultAsync();
            //?? throw new ArgumentException("No hay un corte actual de inventario. Verifique si se ha dado de alta algún producto o contacte a un administrador.");
    }
}
