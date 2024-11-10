using QUICK_INVENTORY.Data.Services;
using QUICK_INVENTORY.Data.Services.Application;

namespace QUICK_INVENTORY.Helpers.Services;

public class ApplicationServices(IGeneralService generalService, IProductosService productos, IProductoRegistrosService productoRegistros) : IApplicationServices
{
    public IGeneralService GeneralService { get => generalService; }
    public IProductosService Productos { get => productos; }
    public IProductoRegistrosService ProductoRegistros { get => productoRegistros; }
}
