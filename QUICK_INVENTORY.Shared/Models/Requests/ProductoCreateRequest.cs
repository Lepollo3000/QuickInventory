using QUICK_INVENTORY.Shared.Helpers.Attributes;
using System.ComponentModel.DataAnnotations;

namespace QUICK_INVENTORY.Shared.Models.Requests;

public class ProductoCreateRequest
{
    [Display(Name = "Código de Barras", Description = "Si no se agrega, se generará uno automáticamente.")]
    public string? CodigoBarras { get; set; } = null!;
    [Requerido]
    [Display(Name = "Locación", Description = "Ej: R1D02-1.")]
    public string Locacion { get; set; } = null!;
    [Requerido]
    [Display(Name = "Nombre", Description = "Nombre breve del producto.")]
    public string Nombre { get; set; } = null!;
    [Requerido]
    [Display(Name = "Descripción", Description = "Descripción del producto.")]
    public string Descripcion { get; set; } = null!;
    [Requerido]
    [Display(Name = "Unidad de Medida", Description = "La forma en que se medirá el stock del producto.")]
    public EnumStockMedida StockMedidaId { get; set; }
    [Requerido]
    [MayorQueCero]
    [Display(Name = "Stock Actual", Description = "Stock con el que iniciará el producto.")]
    public int Stock { get; set; }
    [Requerido]
    [MayorQueCero]
    [Display(Name = "Stock Mínimo", Description = "Límite mínimo del stock que deberá tener el producto antes de que el sistema detecte que se debe surtir.")]
    public int StockMinimo { get; set; }
    [Requerido]
    [MayorQue(nameof(StockMinimo))]
    [Display(Name = "Stock Máximo", Description = "Límite máximo del stock que deberá tener el producto antes de que el sistema detecte que no se debe surtir más.")]
    public int StockMaximo { get; set; }
}
