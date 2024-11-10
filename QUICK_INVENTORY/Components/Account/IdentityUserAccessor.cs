using Microsoft.AspNetCore.Identity;
using QUICK_INVENTORY.Domain;

namespace QUICK_INVENTORY.Components.Account;
internal sealed class IdentityUserAccessor(UserManager<IdentidadUsuario> userManager, IdentityRedirectManager redirectManager)
{
    public async Task<IdentidadUsuario> GetRequiredUserAsync(HttpContext context)
    {
        var user = await userManager.GetUserAsync(context.User);

        if (user is null)
        {
            redirectManager.RedirectToWithStatus("Account/InvalidUser", $"Error: Unable to load user with ID '{userManager.GetUserId(context.User)}'.", context);
        }

        return user;
    }
}
