using QUICK_INVENTORY.Client.Data.Services.Application;

namespace QUICK_INVENTORY.Client.Data.Services;

internal interface IApplicationServices
{
    IProductoRegistrosService ProductoRegistros { get; }
}
