using Microsoft.EntityFrameworkCore;
using QUICK_INVENTORY.Server.Domain.Abstractions;
using QUICK_INVENTORY.Shared.Models;
using QUICK_INVENTORY.Shared.Models.Requests;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace QUICK_INVENTORY.Server.Domain;

[PrimaryKey(nameof(Folio), nameof(RegistroTipoId))]
public class ProductoRegistro : Entidad
{
    public required int Folio { get; set; }
    public required int ProductoId { get; init; }
    public required EnumRegistroTipo RegistroTipoId { get; init; }
    public required string Empleado { get; init; }
    public required int? NumeroExterno { get; init; }
    public required int? NumeroInterno { get; init; }


    [ForeignKey(nameof(RegistroTipoId))]
    public virtual RegistroTipo RegistroTipo { get; set; } = null!;
    [ForeignKey(nameof(ProductoId))]
    public virtual Producto Producto { get; set; } = null!;


    public ProductoRegistro() : base() { }

    [SetsRequiredMembers]
    public ProductoRegistro(ProductoRegistroCreateRequest createRequest, int folio, IdentidadUsuario usuario) : base(usuario)
    {
        Folio = folio;
        RegistroTipoId = createRequest.RegistroTipoId;
        ProductoId = createRequest.ProductoId;
        Empleado = createRequest.Empleado;
        NumeroExterno = createRequest.NumeroExterno;
        NumeroInterno = createRequest.NumeroInterno;
    }
}
