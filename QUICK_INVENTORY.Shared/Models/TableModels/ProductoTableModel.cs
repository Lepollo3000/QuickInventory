using System.ComponentModel.DataAnnotations;

namespace QUICK_INVENTORY.Shared.Models.TableModels;

public class ProductoTableModel
{
    public int Id { get; set; }
    [Display(Name = "Código de Barras")]
    public string CodigoBarras { get; set; } = null!;
    [Display(Name = "Locación")]
    public string Locacion { get; set; } = null!;
    [Display(Name = "Nombre")]
    public string Nombre { get; set; } = null!;
    [Display(Name = "Descripción")]
    public string Descripcion { get; set; } = null!;
    [Display(Name = "Medida")]
    public EnumStockMedida StockMedidaId { get; set; }
    [Display(Name = "Stock Mínimo")]
    public int StockMinimo { get; set; }
    [Display(Name = "Stock Máximo")]
    public int StockMaximo { get; set; }
    [Display(Name = "Stock")]
    public int Stock { get; set; }
}
