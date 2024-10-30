using System.ComponentModel.DataAnnotations;

namespace QUICK_INVENTORY.Shared.Models;

public enum EnumRegistroTipo
{
    [Display(Name = "Entrada")]
    Entrada = 1,
    [Display(Name = "Salida")]
    Salida = 2
}
