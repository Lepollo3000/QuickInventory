using System.ComponentModel.DataAnnotations.Schema;

namespace QUICK_INVENTORY.Server.Domain.Abstractions;

public class Entidad
{
    public required DateTime FechaAlta { get; init; }
    public DateTime? FechaEdita { get; set; } = null;
    public DateTime? FechaElimina { get; set; } = null;
    public required int UsuarioAltaId { get; init; }
    public int? UsuarioEditaId { get; set; } = null;
    public int? UsuarioEliminaId { get; set; } = null;
    public bool EstaEliminado { get; set; } = false;


    [ForeignKey(nameof(UsuarioAltaId))]
    public IdentidadUsuario UsuarioAlta { get; init; } = null!;
    [ForeignKey(nameof(UsuarioEditaId))]
    public IdentidadUsuario? UsuarioEdita { get; set; }
    [ForeignKey(nameof(UsuarioEliminaId))]
    public IdentidadUsuario? UsuarioElimina { get; set; }


    public Entidad() { }

    public Entidad(IdentidadUsuario usuario)
    {
        FechaAlta = DateTime.UtcNow;
        UsuarioAltaId = usuario.Id;
    }

    public void Actualizar(IdentidadUsuario usuario)
    {
        FechaEdita = DateTime.UtcNow;
        UsuarioEditaId = usuario.Id;
    }

    public void Eliminar(IdentidadUsuario usuario)
    {
        FechaElimina = DateTime.UtcNow;
        UsuarioEliminaId = usuario.Id;
    }
}
