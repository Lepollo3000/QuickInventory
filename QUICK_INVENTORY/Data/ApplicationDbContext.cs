using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QUICK_INVENTORY.Domain;

namespace QUICK_INVENTORY.Data;
public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<IdentidadUsuario, IdentidadRol, int>(options)
{
    public virtual DbSet<StockMedida> StockMedidas { get; set; }
    public virtual DbSet<RegistroTipo> RegistroTipos { get; set; }
    public virtual DbSet<Producto> Productos { get; set; }
    public virtual DbSet<ProductoRegistro> ProductoRegistros { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
