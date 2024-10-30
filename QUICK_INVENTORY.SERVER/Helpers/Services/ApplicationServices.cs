using QUICK_INVENTORY.Server.Data.Services;
using QUICK_INVENTORY.Server.Data.Services.Application;

namespace QUICK_INVENTORY.Server.Helpers.Services;

public class ApplicationServices(IGeneralService generalService, IProductoRegistrosService productoRegistros) : IApplicationServices
{
    public IGeneralService GeneralService { get => generalService; }
    public IProductoRegistrosService ProductoRegistros { get => productoRegistros; }
}
