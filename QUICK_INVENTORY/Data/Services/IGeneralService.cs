using QUICK_INVENTORY.Domain;
using System.Security.Claims;

namespace QUICK_INVENTORY.Data.Services;

public interface IGeneralService
{
    Task<IdentidadUsuario> ConsultarUsuario(ClaimsPrincipal user);
}
