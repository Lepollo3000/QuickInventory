using System.ComponentModel.DataAnnotations;

namespace QUICK_INVENTORY.Shared.Models.TableModels;

public class InventarioDetalleTableModel
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
    [Display(Name = "Medida")]
    public string StockMedida { get; set; } = null!;
    [Display(Name = "Stock Mínimo")]
    public int StockMinimo { get; set; }
    [Display(Name = "Stock Máximo")]
    public int StockMaximo { get; set; }

    [Display(Name = "Stock Inicial")]
    public int StockInicial { get; set; }
    [Display(Name = "Stock Final")]
    public int StockFinal { get; set; }
    [Display(Name = "Entradas")]
    public int CantidadEntradas { get; set; }
    [Display(Name = "Salidas")]
    public int CantidadSalidas { get; set; }
}
