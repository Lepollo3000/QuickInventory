using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using QuickInventory.Server.Helpers;
using QuickInventory.Server.Models;

namespace QuickInventory.Server.Data;
public class ApplicationDbContext : KeyApiAuthorizationDbContext<ApplicationUser, ApplicationRole, int>
{
    public ApplicationDbContext(
        DbContextOptions options,
        IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
    {
    }
}
