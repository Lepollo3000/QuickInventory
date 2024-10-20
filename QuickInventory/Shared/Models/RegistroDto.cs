using System.ComponentModel.DataAnnotations;

namespace QuickInventory.Shared.Models;

public class RegistroDto
{
    [Required]
    public int ProductoId { get; set; }
    [Required]
    public int Cantidad { get; set; }
    [Required]
    public EnumRegistroTipo RegistroTipo { get; set; }
}
