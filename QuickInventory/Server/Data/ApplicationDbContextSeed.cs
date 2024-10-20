using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using QuickInventory.Server.Data;
using QuickInventory.Server.Models;

namespace NOAM_ASISTENCIA_v3.Server.Data;

public class ApplicationDbContextSeed : IHostedService
{
    private readonly IConfiguration _configuration;
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<ApplicationRole> _roleManager;
    private readonly ILogger<ApplicationDbContextSeed> _logger;

    public ApplicationDbContextSeed(IServiceProvider serviceProvider, IConfiguration configuration)
    {
        var scope = serviceProvider.CreateAsyncScope();

        _context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        _userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
        _roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<ApplicationRole>>();
        _logger = scope.ServiceProvider.GetRequiredService<ILogger<ApplicationDbContextSeed>>();

        _configuration = configuration;
    }

    public async Task StartAsync(CancellationToken cancellationToken) => await InitializeDatabase();

    public async Task StopAsync(CancellationToken cancellationToken) => await Task.CompletedTask;

    #region Initialize database
    private async Task InitializeDatabase()
    {
        if (await TryToMigrate())
        {
            await SeedDefaultData();
            await SeedDefaultUsersAndRoles();
        }
    }

    private async Task<bool> TryToMigrate()
    {
        try
        {
            await _context.Database.MigrateAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError("Error al migrar la base de datos. '{ex}'.", ex);

            return false;
        }

        return true;
    }
    #endregion

    #region Seed super user
    private async Task SeedSuperUser()
    {
        await SeedDefaultUsersAndRoles(insertSuperUser: true);
    }

    private async Task<ApplicationUser?> GetSuperUser()
    {
        return await _userManager.FindByNameAsync("administrador");
    }
    #endregion

    #region Seed default data
    private async Task SeedDefaultData()
    {
        try
        {
            await SeedSuperUser();

            ApplicationUser? usuario = await GetSuperUser();

            if (usuario != null)
            {
                //await InsertDefaultSucursales(usuario);
                //TempTurno turno = await InsertDefaultTurnos(usuario);

                //return [turno];
                return;
            }

            throw new InvalidOperationException("No se encontró un usuario para crear los datos predeterminados.");
        }
        catch (Exception ex)
        {
            _logger.LogError("Error al crear datos predeterminados. '{ex}'.", ex.Message);

            throw;
        }
    }
    #endregion

    #region Seed default user and roles
    private async Task SeedDefaultUsersAndRoles(bool insertSuperUser = false)
    {
        try
        {
            string adminRole = "Administrador";

            TempUser adminUser = new(
                Name: "administrador",
                Email: string.Empty,
                Password: "Pa55w.rd",
                Nombre: "ApplicationUser",
                Apellido: "Administrador",
                Roles: new[] { adminRole });

            TempUser normalUser = new(
                Name: "usuario",
                Email: string.Empty,
                Password: "Pa55w.rd",
                Nombre: "ApplicationUser",
                Apellido: "Normal",
                Roles: Enumerable.Empty<string>());

            IEnumerable<string> roles = new[] { adminRole };
            IEnumerable<TempUser> tempUsers = insertSuperUser switch
            {
                true => new[] { adminUser },
                false => new[] { normalUser }
            };
            ApplicationUser? superUsuario = insertSuperUser switch
            {
                true => null,
                false => await GetSuperUser()
            };

            await CreateRolesIfDontExist(roles);
            await CreateUsersIfDontExist(tempUsers: tempUsers, superUsuario: superUsuario);
        }
        catch (Exception ex)
        {
            _logger.LogError("Error al crear usuario y roles predeterminados. '{ex}'.", ex.Message);
        }
    }

    private async Task CreateRolesIfDontExist(IEnumerable<string> roles)
    {
        foreach (string role in roles)
        {
            ApplicationRole? model = await _roleManager.FindByNameAsync(role);

            if (model == null)
            {
                model = new ApplicationRole()
                {
                    Name = role
                };

                await _roleManager.CreateAsync(model);
            }
        }
    }

    private async Task CreateUsersIfDontExist(IEnumerable<TempUser> tempUsers, ApplicationUser? superUsuario)
    {
        foreach (TempUser tempUser in tempUsers)
        {
            ApplicationUser? user = await _userManager.FindByNameAsync(tempUser.Name);

            if (user == null)
            {
                user = new ApplicationUser()
                {
                    UserName = tempUser.Name,
                    Email = tempUser.Email
                };

                await _userManager.CreateAsync(user, tempUser.Password);
                string token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                await _userManager.ConfirmEmailAsync(user, token);

                if (tempUser.Roles.Any())
                {
                    await _userManager.AddToRolesAsync(user, tempUser.Roles);
                }
            }
        }
    }
    #endregion

    #region Clases temporales
    private record TempUser(string Name, string Email, string Password, string Nombre, string Apellido, IEnumerable<string> Roles);

    //private record TempSucursal(SucursalId Id, string CodigoId, string Descripcion);

    //private record TempTurnoDia(DayOfWeek Dia);
    //private record TempTurno(TurnoId Id, TimeOnly HoraInicio, TimeOnly HoraFin, IEnumerable<TempTurnoDia> Dias);
    #endregion
}
