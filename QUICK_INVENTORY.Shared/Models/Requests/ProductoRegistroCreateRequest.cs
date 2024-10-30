using QUICK_INVENTORY.Shared.Helpers;
using System.ComponentModel.DataAnnotations;

namespace QUICK_INVENTORY.Shared.Models.Requests;

public class ProductoRegistroCreateRequest
{
    [Required(ErrorMessage = GeneralErrors.CampoRequerido)]
    [Range(1, int.MaxValue, ErrorMessage = GeneralErrors.CampoNoDeberSerCero)]
    public int ProductoId { get; set; }
    [Required(ErrorMessage = GeneralErrors.CampoRequerido)]
    public EnumRegistroTipo RegistroTipoId { get; set; }
    [Required(AllowEmptyStrings = false, ErrorMessage = GeneralErrors.CampoRequerido)]
    public string Empleado { get; set; } = null!;
    [Required(ErrorMessage = GeneralErrors.CampoRequerido)]
    [Range(1, int.MaxValue, ErrorMessage = GeneralErrors.CampoNoDeberSerCero)]
    public int Cantidad { get; set; }
    [Required(ErrorMessage = GeneralErrors.CampoRequerido)]
    public int NumeroExterno { get; set; }
    [Required(ErrorMessage = GeneralErrors.CampoRequerido)]
    public int NumeroInterno { get; set; }
};
