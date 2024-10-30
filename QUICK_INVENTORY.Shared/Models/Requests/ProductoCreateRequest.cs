using Foolproof;
using System.ComponentModel.DataAnnotations;

namespace QUICK_INVENTORY.Shared.Models.Requests;

public class ProductoCreateRequest
{
    [Required(AllowEmptyStrings = false)]
    public string CodigoBarras { get; set; } = null!;
    [Required(AllowEmptyStrings = false)]
    public string Locacion { get; set; } = null!;
    [Required(AllowEmptyStrings = false)]
    public string Nombre { get; set; } = null!;
    [Required(AllowEmptyStrings = false)]
    public string Descripcion { get; set; } = null!;
    [Required]
    public EnumStockMedida StockMedida { get; set; }
    [Required]
    [Range(1, int.MaxValue)]
    public int StockMinimo { get; set; }
    [Required]
    [GreaterThan(nameof(StockMinimo))]
    [Range(1, int.MaxValue)]
    public int StockMaximo { get; set; }
}
