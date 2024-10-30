using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QUICK_INVENTORY.Server.Domain.Abstractions;
using QUICK_INVENTORY.Shared.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace QUICK_INVENTORY.Server.Domain;

public class RegistroTipo : EntidadPrimaria<EnumRegistroTipo>
{
    public class IdConverter() : ValueConverter<EnumRegistroTipo, int>
        (value => (int)value, intValue => (EnumRegistroTipo)intValue);


    public required string Descripcion { get; set; }


    [InverseProperty(nameof(ProductoRegistro.RegistroTipo))]
    public virtual ICollection<ProductoRegistro> Registros { get; set; } = null!;


    public RegistroTipo() : base() { }

    [SetsRequiredMembers]
    public RegistroTipo(EnumRegistroTipo id, string descripcion, IdentidadUsuario usuario) : base(id, usuario)
    {
        Descripcion = descripcion;
    }
}
