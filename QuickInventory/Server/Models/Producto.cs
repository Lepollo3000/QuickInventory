using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuickInventory.Server.Models;

public class Producto
{
    public int Id { get; set; }
    [MaxLength(100)]
    public string CodigoBarras { get; set; } = null!;
    [MaxLength(500)]
    public string Nombre { get; set; } = null!;
    [MaxLength(500)]
    public string Locacion { get; set; } = null!;
    [MaxLength(1500)]
    public string Descripcion { get; set; } = null!;
    public int StockMinimo { get; set; }
    public int StockMaximo { get; set; }
    public int StockUnidadId { get; set; }

    [ForeignKey(nameof(StockUnidadId))]
    public StockUnidad StockUnidad { get; set; } = null!;
}
