using QUICK_INVENTORY.Client.Data.Services.Application;

namespace QUICK_INVENTORY.Client.Data.Services;

public interface IApplicationServices
{
    IProductoRegistrosService ProductoRegistros { get; }
}
