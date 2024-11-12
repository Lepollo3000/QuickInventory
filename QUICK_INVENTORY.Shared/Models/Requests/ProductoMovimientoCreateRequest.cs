using QUICK_INVENTORY.Shared.Helpers.Attributes;
using System.ComponentModel.DataAnnotations;

namespace QUICK_INVENTORY.Shared.Models.Requests;

public class ProductoMovimientoCreateRequest
{
    [Requerido(ErrorMessage = "Se requiere buscar el producto.")]
    [MayorQueCero(ErrorMessage = "Se requiere buscar el producto.")]
    [Display(Name = "Producto", Description = "El producto al cual afectará el movimiento.")]
    public int ProductoId { get; set; }
    [Requerido]
    [Display(Name = "Tipo de Movimiento", Description = "La afectación que se le realizará al producto.")]
    public EnumMovimientoTipo MovimientoTipoId { get; set; }
    [Requerido]
    [Display(Name = "Número de Empleado", Description = "El número de empleado implicado en el movimiento (si tiene gafette, escanealo).")]
    public string Empleado { get; set; } = null!;
    [Requerido]
    [MayorQueCero]
    [Display(Name = "Cantidad de Producto", Description = "La cantidad de producto que se registrará en el stock del mismo.")]
    public int MovimientoCantidad { get; set; }
    [Display(Name = "N.S. Externo", Description = "Departamento al que pertenece el empleado implicado.")]
    public string? NumeroExterno { get; set; } = null!;
    [Display(Name = "N.S. Interno", Description = "Si no se ingresa, será el mismo valor de N.S. Externo.")]
    public string? NumeroInterno { get; set; }
};
