using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using QUICK_INVENTORY.Server.Domain;
using QUICK_INVENTORY.Server.Helpers;

namespace QUICK_INVENTORY.Server.Data;

public partial class ApplicationDbContext(DbContextOptions options, IOptions<OperationalStoreOptions> operationalStoreOptions)
: KeyApiAuthorizationDbContext<IdentidadUsuario, IdentidadRol, int>(options, operationalStoreOptions)
{
    public virtual DbSet<StockMedida> StockMedidas { get; set; }
    public virtual DbSet<RegistroTipo> RegistroTipos { get; set; }
    public virtual DbSet<Producto> Productos { get; set; }
    public virtual DbSet<ProductoRegistro> ProductoRegistros { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        //modelBuilder.Entity<StockMedida>(entity =>
        //{
        //    entity.Property(e => e.Id)
        //        .HasConversion<StockMedida.IdConverter>();
        //});

        //modelBuilder.Entity<RegistroTipo>(entity =>
        //{
        //    entity.Property(e => e.Id)
        //        .HasConversion<RegistroTipo.IdConverter>();
        //});
    }
}
