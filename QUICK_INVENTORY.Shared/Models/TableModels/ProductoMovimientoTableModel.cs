namespace QUICK_INVENTORY.Shared.Models.TableModels;

public class ProductoMovimientoTableModel
{
    public int Folio { get; set; }
    public string Producto { get; set; } = null!;
    public int Cantidad { get; set; }
    public EnumMovimientoTipo MovimientoTipoId { get; set; }
    public string NumeroExterno { get; set; } = null!;
    public string NumeroInterno { get; set; } = null!;
}
