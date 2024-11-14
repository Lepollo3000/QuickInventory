using QUICK_INVENTORY.Domain.Abstractions;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace QUICK_INVENTORY.Domain;

public class InventarioCorte : EntidadPrimaria<int>
{
    public required DateTime FechaInicio { get; set; }
    public required DateTime? FechaFin { get; set; }


    [InverseProperty(nameof(InventarioCorteDetalle.InventarioCorte))]
    public virtual ICollection<InventarioCorteDetalle> Detalles { get; set; } = null!;


    public InventarioCorte() : base() { }

    [SetsRequiredMembers]
    public InventarioCorte(IdentidadUsuario usuario) : base(usuario)
    {
        FechaInicio = DateTime.UtcNow;
        FechaFin = null;
    }
}
