using QUICK_INVENTORY.Server.Domain.Abstractions;
using QUICK_INVENTORY.Shared;
using QUICK_INVENTORY.Shared.Models.Requests;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace QUICK_INVENTORY.Server.Domain;

public class Producto : EntidadPrimaria<int>
{
    [MaxLength(100)]
    public required string CodigoBarras { get; set; }
    [MaxLength(500)]
    public required string Locacion { get; set; }
    [MaxLength(500)]
    public required string Nombre { get; set; }
    [MaxLength(1500)]
    public required string Descripcion { get; set; }
    public required EnumStockMedida StockMedidaId { get; set; }
    public required int StockMinimo { get; set; }
    public required int StockMaximo { get; set; }
    public required int Stock { get; set; }


    [ForeignKey(nameof(StockMedidaId))]
    public virtual StockMedida StockMedida { get; set; } = null!;


    [InverseProperty(nameof(ProductoRegistro.Producto))]
    public virtual ICollection<ProductoRegistro> Registros { get; set; } = null!;
    [InverseProperty(nameof(InventarioCorteDetalle.Producto))]
    public virtual ICollection<InventarioCorteDetalle> InventarioCortes { get; set; } = null!;


    public Producto() : base() { }

    [SetsRequiredMembers]
    public Producto(ProductoCreateRequest createRequest, IdentidadUsuario usuario) : base(usuario)
    {
        CodigoBarras = createRequest.CodigoBarras;
        Locacion = createRequest.Locacion;
        Nombre = createRequest.Nombre;
        Descripcion = createRequest.Descripcion;
        StockMedidaId = createRequest.StockMedida;
        StockMinimo = createRequest.StockMinimo;
        StockMaximo = createRequest.StockMaximo;
    }
}
