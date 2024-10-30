using Microsoft.EntityFrameworkCore;
using QUICK_INVENTORY.Server.Domain.Abstractions;
using System.ComponentModel.DataAnnotations.Schema;

namespace QUICK_INVENTORY.Server.Domain;

[PrimaryKey(nameof(ProductoId), nameof(InventarioCorteId))]
public class InventarioCorteDetalle : Entidad
{
    public required int ProductoId { get; set; }
    public required int InventarioCorteId { get; set; }
    public required int StockInicial { get; set; }
    public required int StockFinal { get; set; }


    [ForeignKey(nameof(ProductoId))]
    public virtual Producto Producto { get; set; } = null!;
    [ForeignKey(nameof(InventarioCorteId))]
    public virtual InventarioCorte InventarioCorte { get; set; } = null!;
}
