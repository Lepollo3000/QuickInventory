using QUICK_INVENTORY.Client.Data.Services;
using QUICK_INVENTORY.Client.Data.Services.Application;

namespace QUICK_INVENTORY.Client.Helpers.Services;

public class ApplicationServices(IProductoRegistrosService productoRegistros) : IApplicationServices
{
    public IProductoRegistrosService ProductoRegistros { get => productoRegistros; }
}
