using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MudBlazor;
using QUICK_INVENTORY.Domain;
using QUICK_INVENTORY.Helpers.Identity;
using QUICK_INVENTORY.Shared.Helpers;
using QUICK_INVENTORY.Shared.Models;

namespace QUICK_INVENTORY.Data;

public class ApplicationDbContextSeed : IHostedService
{
    private readonly IConfiguration _configuration;
    private readonly ApplicationDbContext _context;
    private readonly IUserStore<IdentidadUsuario> _userStore;
    private readonly UserManager<IdentidadUsuario> _userManager;
    private readonly RoleManager<IdentidadRol> _roleManager;
    private readonly ILogger<ApplicationDbContextSeed> _logger;

    public ApplicationDbContextSeed(IServiceProvider serviceProvider, IConfiguration configuration)
    {
        var scope = serviceProvider.CreateAsyncScope();

        _context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        _userStore = scope.ServiceProvider.GetRequiredService<IUserStore<IdentidadUsuario>>();
        _userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentidadUsuario>>();
        _roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentidadRol>>();
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
    private async Task SeedSuperUser(bool insertSuperUSer)
    {
        await SeedDefaultUsersAndRoles(insertSuperUser: insertSuperUSer);
    }

    private async Task<IdentidadUsuario?> GetSuperUser()
    {
        return await _userManager.FindByNameAsync("admin");
    }
    #endregion

    #region Seed default data
    private async Task SeedDefaultData()
    {
        try
        {
            await SeedSuperUser(insertSuperUSer: true);

            IdentidadUsuario? usuario = await GetSuperUser();

            if (usuario != null)
            {
                await InsertDefaultStockMedidas(usuario);
                await InsertDefaultRegistroTipos(usuario);

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

    private async Task InsertDefaultStockMedidas(IdentidadUsuario usuario)
    {
        IEnumerable<EnumStockMedida>
        temporales = Enum
            .GetValues(typeof(EnumStockMedida))
            .Cast<EnumStockMedida>()
            .ToList();

        foreach (EnumStockMedida temporal in temporales)
        {
            bool existe = await _context.StockMedidas
                .Where(model => model.Id == temporal)
                .AnyAsync();

            if (!existe)
            {
                StockMedida stockMedida = new(
                    id: temporal,
                    descripcion: temporal.GetDisplayName(),
                    usuario: usuario);

                _context.Add(stockMedida);
            }
        }

        await _context.SaveChangesWithIdentityInsertAsync<StockMedida>();
    }

    private async Task InsertDefaultRegistroTipos(IdentidadUsuario usuario)
    {
        IEnumerable<EnumMovimientoTipo>
        temporales = Enum
            .GetValues(typeof(EnumMovimientoTipo))
            .Cast<EnumMovimientoTipo>()
            .ToList();

        foreach (EnumMovimientoTipo temporal in temporales)
        {
            bool existe = await _context.MovimientoTipos
                .Where(model => model.Id == temporal)
                .AnyAsync();

            if (!existe)
            {
                MovimientoTipo registroTipo = new(
                    id: temporal,
                    descripcion: temporal.GetDisplayName(),
                    usuario: usuario);

                _context.Add(registroTipo);
            }
        }

        await _context.SaveChangesWithIdentityInsertAsync<MovimientoTipo>();
    }
    #endregion

    #region Seed default user and roles
    private async Task SeedDefaultUsersAndRoles(bool insertSuperUser = false)
    {
        try
        {
            string adminRole = "Administrador";

            TempUser adminUser = new(
                Name: "admin",
                Email: string.Empty,
                Password: "Pa55w.rd",
                Nombre: "ApplicationUser",
                Apellido: "Administrador",
                Roles: [adminRole]);

            TempUser normalUser = new(
                Name: "usuario",
                Email: string.Empty,
                Password: "Pa55w.rd",
                Nombre: "ApplicationUser",
                Apellido: "Normal",
                Roles: []);

            IEnumerable<string> roles = [adminRole];
            IEnumerable<TempUser> tempUsers = insertSuperUser switch
            {
                true => [adminUser],
                false => [normalUser]
            };
            IdentidadUsuario? superUsuario = insertSuperUser switch
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
            IdentidadRol? model = await _roleManager.FindByNameAsync(role);

            if (model == null)
            {
                model = new IdentidadRol()
                {
                    Name = role
                };

                await _roleManager.CreateAsync(model);
            }
        }
    }

    private async Task CreateUsersIfDontExist(IEnumerable<TempUser> tempUsers, IdentidadUsuario? superUsuario)
    {
        foreach (TempUser tempUser in tempUsers)
        {
            IdentidadUsuario? user = await _userManager.FindByNameAsync(tempUser.Name);

            if (user == null)
            {

                user = Activator.CreateInstance<IdentidadUsuario>();

                await _userStore.SetUserNameAsync(user, tempUser.Name, CancellationToken.None);
                var emailStore = (IUserEmailStore<IdentidadUsuario>)_userStore;

                await emailStore.SetEmailAsync(user, tempUser.Name, CancellationToken.None);
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

    private record TempStockMedida(int Id, string Descripcion);
    private record TempRegistroTipo(int Id, string Descripcion);
    private record TempProducto(int Id, string CodigoBarras, string Locacion, string Nombre, EnumStockMedida StockMedida);

    //private record TempTurnoDia(DayOfWeek Dia);
    //private record TempTurno(TurnoId Id, TimeOnly HoraInicio, TimeOnly HoraFin, IEnumerable<TempTurnoDia> Dias);
    #endregion
}
