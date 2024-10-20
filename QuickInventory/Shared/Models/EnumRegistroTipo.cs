using System.ComponentModel.DataAnnotations;

namespace QuickInventory.Shared.Models;

public enum EnumRegistroTipo
{
    [Display(Name = "Entrada")]
    Entrada,
    [Display(Name = "Salida")]
    Salida
}
