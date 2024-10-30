using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QUICK_INVENTORY.Server.Domain.Abstractions;
using QUICK_INVENTORY.Shared;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace QUICK_INVENTORY.Server.Domain;

public class StockMedida : EntidadPrimaria<EnumStockMedida>
{
    public class IdConverter() : ValueConverter<EnumStockMedida, int>
        (value => (int)value, intValue => (EnumStockMedida)intValue);


    public required string Descripcion { get; set; }


    [InverseProperty(nameof(Producto.StockMedida))]
    public virtual ICollection<Producto> Productos { get; set; } = null!;


    public StockMedida() : base() { }

    [SetsRequiredMembers]
    public StockMedida(EnumStockMedida id, string descripcion, IdentidadUsuario usuario) : base(id, usuario)
    {
        Descripcion = descripcion;
    }
}
