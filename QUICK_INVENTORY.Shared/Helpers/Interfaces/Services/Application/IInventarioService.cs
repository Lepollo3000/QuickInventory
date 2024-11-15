using Ardalis.Result;
using QUICK_INVENTORY.Shared.Models.TableModels;

namespace QUICK_INVENTORY.Shared.Helpers.Interfaces.Services.Application;

public interface IInventarioService
{
    Task<Result<IEnumerable<InventarioDetalleTableModel>>> ConsultarDetallesCorteActual();
}
