using QUICK_INVENTORY.Server.Data.Services.Application;

namespace QUICK_INVENTORY.Server.Data.Services;

public interface IApplicationServices
{
    IGeneralService GeneralService { get; }
    IProductoRegistrosService ProductoRegistros { get; }
}
