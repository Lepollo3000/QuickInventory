using QUICK_INVENTORY.Data.Services.Application;

namespace QUICK_INVENTORY.Data.Services;

public interface IApplicationServices
{
    IGeneralService GeneralService { get; }
    IProductosService Productos { get; }
    IProductoRegistrosService ProductoRegistros { get; }
}
