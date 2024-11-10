using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace QUICK_INVENTORY.Domain.Abstractions;

[PrimaryKey(nameof(Id))]
public class EntidadPrimaria<T> : Entidad
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public T Id { get; set; }

    public EntidadPrimaria() : base() { }

    public EntidadPrimaria(IdentidadUsuario usuario) : base(usuario) { }

    public EntidadPrimaria(T id, IdentidadUsuario usuario) : base(usuario)
    {
        Id = id;
    }
}
