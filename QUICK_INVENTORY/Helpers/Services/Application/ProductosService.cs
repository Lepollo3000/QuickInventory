using Microsoft.EntityFrameworkCore;
using QUICK_INVENTORY.Data;
using QUICK_INVENTORY.Data.Repositories;
using QUICK_INVENTORY.Data.Services.Application;
using QUICK_INVENTORY.Domain;
using QUICK_INVENTORY.Shared.Models.Requests;
using QUICK_INVENTORY.Shared.Models.TableModels;

namespace QUICK_INVENTORY.Helpers.Services.Application;

public class ProductosService(IApplicationRepositories repositories) : IProductosService
{
    private readonly IApplicationRepositories _repositories = repositories;
    private readonly ApplicationDbContext _context = repositories.General.Context;

    public async Task<ProductoTableModel?> ConsultarProducto(ProductoSearchRequest request)
    {
        return await _context.Productos
            .Where(model => !model.EstaEliminado)
            .Where(model => model.CodigoBarras == request.CodigoBarras)
            .Select(model =>
                new ProductoTableModel
                {
                    Id = model.Id,
                    CodigoBarras = model.CodigoBarras,
                    Locacion = model.Locacion,
                    Nombre = model.Nombre,
                    Descripcion = model.Descripcion,
                    StockMedidaId = model.StockMedidaId,
                    StockMinimo = model.StockMinimo,
                    StockMaximo = model.StockMaximo,
                    Stock = model.Stock
                })
            .FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<ProductoTableModel>> ConsultarProductos(ProductoSearchRequest searchRequest)
    {
        IQueryable<Producto> query = _context.Productos
            .Where(model => !model.EstaEliminado);

        if (searchRequest.CodigoBarras != null
        || searchRequest.BuscarIndividualmente)
        {
            query = query
                .Where(model => model.CodigoBarras
                    == (searchRequest.CodigoBarras ?? string.Empty));
        }

        return await query
            .Select(model =>
                new ProductoTableModel
                {
                    Id = model.Id,
                    CodigoBarras = model.CodigoBarras,
                    Locacion = model.Locacion,
                    Nombre = model.Nombre,
                    Descripcion = model.Descripcion,
                    StockMedidaId = model.StockMedidaId,
                    StockMinimo = model.StockMinimo,
                    StockMaximo = model.StockMaximo,
                    Stock = model.Stock
                })
            .ToListAsync();
    }

    public async Task<Producto> InsertarProducto(ProductoCreateRequest request, IdentidadUsuario usuario)
    {
        await Task.CompletedTask;

        var producto =
           new Producto(
               createRequest: request,
               usuario: usuario);

        _repositories.General.Context.Add(producto);

        return producto;
    }
}
