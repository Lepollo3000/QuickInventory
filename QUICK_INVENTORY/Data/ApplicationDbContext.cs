using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QUICK_INVENTORY.Domain;

namespace QUICK_INVENTORY.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<IdentidadUsuario, IdentidadRol, int>(options)
{
    public virtual DbSet<StockMedida> StockMedidas { get; set; }
    public virtual DbSet<MovimientoTipo> MovimientoTipos { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }
    public virtual DbSet<ProductoMovimiento> ProductoMovimientos { get; set; }

    public virtual DbSet<InventarioCorte> InventarioCortes { get; set; }
    public virtual DbSet<InventarioCorteDetalle> InventarioCorteDetalles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
