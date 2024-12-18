﻿using Microsoft.EntityFrameworkCore;
using QUICK_INVENTORY.Domain.Abstractions;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace QUICK_INVENTORY.Domain;

[PrimaryKey(nameof(ProductoId), nameof(InventarioCorteId))]
public class InventarioCorteDetalle : Entidad
{
    public required int ProductoId { get; set; }
    public required int InventarioCorteId { get; set; }
    public required int StockInicial { get; set; }
    public required int? StockFinal { get; set; }


    [ForeignKey(nameof(ProductoId))]
    public virtual Producto Producto { get; set; } = null!;
    [ForeignKey(nameof(InventarioCorteId))]
    public virtual InventarioCorte InventarioCorte { get; set; } = null!;


    public InventarioCorteDetalle() : base() { }

    [SetsRequiredMembers]
    public InventarioCorteDetalle(Producto producto, InventarioCorte corte, IdentidadUsuario usuario) : base(usuario)
    {
        Producto = producto;
        InventarioCorte = corte;

        StockInicial = producto.Stock;
    }
}
