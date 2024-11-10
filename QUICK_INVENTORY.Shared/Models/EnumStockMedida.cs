using System.ComponentModel.DataAnnotations;

namespace QUICK_INVENTORY.Shared.Models;

public enum EnumStockMedida
{
    [Display(Name = "Pieza")]
    Pieza = 1,
    [Display(Name = "Paquete")]
    Paquete = 2,
    [Display(Name = "Caja")]
    Caja = 3
}
