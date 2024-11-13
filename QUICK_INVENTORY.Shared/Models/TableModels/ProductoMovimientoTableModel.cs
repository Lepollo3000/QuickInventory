using System.ComponentModel.DataAnnotations;

namespace QUICK_INVENTORY.Shared.Models.TableModels;

public class ProductoMovimientoTableModel
{
    [Display(Name = "Folio")]
    public int Folio { get; set; }
    [Display(Name = "Refacción")]
    public string Producto { get; set; } = null!;
    [Display(Name = "Cantidad Implicada")]
    public int MovimientoCantidad { get; set; }
    [Display(Name = "Tipo de Movimiento")]
    public EnumMovimientoTipo MovimientoTipoId { get; set; }
    [Display(Name = "Tipo de Movimiento")]
    public string MovimientoTipo { get; set; } = null!;
    [Display(Name = "N.S. Externo")]
    public string? NumeroExterno { get; set; }
    [Display(Name = "N.S. Interno")]
    public string? NumeroInterno { get; set; }
}
