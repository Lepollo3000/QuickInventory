using Microsoft.EntityFrameworkCore;
using QUICK_INVENTORY.Domain.Abstractions;
using QUICK_INVENTORY.Shared.Models;
using QUICK_INVENTORY.Shared.Models.Requests;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace QUICK_INVENTORY.Domain;

[PrimaryKey(nameof(Folio), nameof(MovimientoTipoId))]
public class ProductoMovimiento : Entidad
{
    public required int Folio { get; init; }
    public required int ProductoId { get; init; }
    public required EnumMovimientoTipo MovimientoTipoId { get; init; }
    public required int MovimientoCantidad { get; set; }
    public required string Empleado { get; init; }
    public required string? NumeroExterno { get; init; }
    public required string? NumeroInterno { get; init; }
    public required DateTime FechaMovimiento { get; init; }


    [ForeignKey(nameof(ProductoId))]
    public virtual Producto Producto { get; set; } = null!;
    [ForeignKey(nameof(MovimientoTipoId))]
    public virtual MovimientoTipo MovimientoTipo { get; set; } = null!;


    public ProductoMovimiento() : base() { }

    [SetsRequiredMembers]
    public ProductoMovimiento(ProductoMovimientoCreateRequest createRequest, int folio, IdentidadUsuario usuario) : base(usuario)
    {
        Folio = folio;
        ProductoId = createRequest.ProductoId;
        MovimientoTipoId = createRequest.MovimientoTipoId;
        MovimientoCantidad = createRequest.MovimientoCantidad;
        Empleado = createRequest.Empleado;
        NumeroExterno = createRequest.NumeroExterno;
        NumeroInterno = createRequest.NumeroInterno
            ?? createRequest.NumeroExterno;
    }
}
