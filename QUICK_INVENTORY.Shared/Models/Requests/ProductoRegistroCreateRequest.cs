using QUICK_INVENTORY.Shared.Helpers;
using System.ComponentModel.DataAnnotations;

namespace QUICK_INVENTORY.Shared.Models.Requests;

public record ProductoRegistroCreateRequest(
    [Required(ErrorMessage = GeneralErrors.CampoRequerido)][Range(minimum: 1, maximum: int.MaxValue, ErrorMessage = GeneralErrors.CampoNoDeberSerCero)] int ProductoId,
    [Required(ErrorMessage = GeneralErrors.CampoRequerido)] EnumRegistroTipo RegistroTipoId,
    [Required(ErrorMessage = GeneralErrors.CampoRequerido)] string Empleado,
    [Required(ErrorMessage = GeneralErrors.CampoRequerido)][Range(minimum: 1, maximum: int.MaxValue, ErrorMessage = GeneralErrors.CampoNoDeberSerCero)] int Cantidad,
    [Required(ErrorMessage = GeneralErrors.CampoRequerido)] int NumeroExterno,
    [Required(ErrorMessage = GeneralErrors.CampoRequerido)] int NumeroInterno);
