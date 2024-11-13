using QUICK_INVENTORY.Shared.Helpers.Attributes;
using System.ComponentModel.DataAnnotations;

namespace QUICK_INVENTORY.Shared.Models.Requests;

public class ProductoSearchRequest
{
    [Display(Name = "Código de Barras", Description = "El código de barras del producto a buscar.")]
    public string? CodigoBarras { get; set; }
}
