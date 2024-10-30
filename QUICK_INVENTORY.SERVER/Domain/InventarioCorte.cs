using QUICK_INVENTORY.Server.Domain.Abstractions;
using System.ComponentModel.DataAnnotations.Schema;

namespace QUICK_INVENTORY.Server.Domain;

public class InventarioCorte : EntidadPrimaria<int>
{
    public DateTime FechaInicio { get; set; }
    public DateTime? FechaFin { get; set; }


    [InverseProperty(nameof(InventarioCorteDetalle.InventarioCorte))]
    public virtual ICollection<InventarioCorteDetalle> Detalles { get; set; } = null!;
}
