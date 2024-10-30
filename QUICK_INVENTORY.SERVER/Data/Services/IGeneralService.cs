using QUICK_INVENTORY.Server.Domain;
using System.Security.Claims;

namespace QUICK_INVENTORY.Server.Data.Services;

public interface IGeneralService
{
    Task<IdentidadUsuario> ConsultarUsuario(ClaimsPrincipal user);
}
