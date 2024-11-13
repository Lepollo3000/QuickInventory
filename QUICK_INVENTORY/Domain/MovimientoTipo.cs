using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QUICK_INVENTORY.Domain.Abstractions;
using QUICK_INVENTORY.Shared.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace QUICK_INVENTORY.Domain;

public class MovimientoTipo : EntidadPrimaria<EnumMovimientoTipo>
{
    public class IdConverter() : ValueConverter<EnumMovimientoTipo, int>
        (value => (int)value, intValue => (EnumMovimientoTipo)intValue);


    public required string Descripcion { get; set; }


    [InverseProperty(nameof(ProductoMovimiento.MovimientoTipo))]
    public virtual ICollection<ProductoMovimiento> Registros { get; set; } = null!;


    public MovimientoTipo() : base() { }

    [SetsRequiredMembers]
    public MovimientoTipo(EnumMovimientoTipo id, string descripcion, IdentidadUsuario usuario) : base(id, usuario)
    {
        Descripcion = descripcion;
    }
}
