using System.ComponentModel.DataAnnotations.Schema;

namespace QuickInventory.Server.Models;

public class StockUnidad
{
    public int Id { get; set; }
    public string Descripcion { get; set; } = null!;

    [InverseProperty(nameof(Producto.StockUnidad))]
    public virtual ICollection<Producto> Productos { get; set; } = null!;
}
