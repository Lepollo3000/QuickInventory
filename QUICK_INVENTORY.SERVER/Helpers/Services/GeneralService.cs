using Microsoft.AspNetCore.Identity;
using QUICK_INVENTORY.Server.Data.Services;
using QUICK_INVENTORY.Server.Domain;
using System.Security.Claims;

namespace QUICK_INVENTORY.Server.Helpers.Services;

public class GeneralService(UserManager<IdentidadUsuario> userManager) : IGeneralService
{
    private readonly UserManager<IdentidadUsuario> _userManager = userManager;

    public async Task<IdentidadUsuario> ConsultarUsuario(ClaimsPrincipal user)
    {
        return await _userManager.GetUserAsync(user)
            ?? throw new ArgumentException("El usuario no se encontró o no existe.");
    }
}
