using QUICK_INVENTORY.Domain;

namespace QUICK_INVENTORY.Data.Repositories.Application;

public interface IProductoRepository
{
    public Task<Producto?> ConsultarProducto(int productoId);
}
