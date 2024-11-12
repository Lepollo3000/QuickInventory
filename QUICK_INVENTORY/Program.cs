using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using QUICK_INVENTORY.Components;
using QUICK_INVENTORY.Components.Account;
using QUICK_INVENTORY.Data;
using QUICK_INVENTORY.Data.Repositories;
using QUICK_INVENTORY.Data.Repositories.Application;
using QUICK_INVENTORY.Data.Services;
using QUICK_INVENTORY.Data.Services.Application;
using QUICK_INVENTORY.Domain;
using QUICK_INVENTORY.Helpers.Repositories;
using QUICK_INVENTORY.Helpers.Repositories.Application;
using QUICK_INVENTORY.Helpers.Services;
using QUICK_INVENTORY.Helpers.Services.Application;
using QUICK_INVENTORY.Shared.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<IdentityUserAccessor>();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<AuthenticationStateProvider, PersistingServerAuthenticationStateProvider>();

builder.Services.AddAuthorization();
builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = IdentityConstants.ApplicationScheme;
        options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
    })
    .AddIdentityCookies();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentityCore<IdentidadUsuario>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentidadRol>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();

builder.Services.AddSingleton<IEmailSender<IdentidadUsuario>, IdentityNoOpEmailSender>();

builder.Services
    .AddControllersWithViews();

builder.Services.AddScoped<IGeneralService, GeneralService>();
builder.Services.AddScoped<IProductosService, ProductosService>();
builder.Services.AddScoped<IProductoRegistrosService, ProductoRegistrosService>();

builder.Services.AddScoped<IGeneralRepository, GeneralRepository>();
builder.Services.AddScoped<IProductoRepository, ProductoRepository>();
builder.Services.AddScoped<IProductoRegistrosRepository, ProductoRegistrosRepository>();

builder.Services.AddScoped<IApplicationServices, ApplicationServices>();
builder.Services.AddScoped<IApplicationRepositories, ApplicationRepositories>();

builder.Services.AddApplicationClientDependencies();

builder.Services
    .AddHostedService<ApplicationDbContextSeed>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(QUICK_INVENTORY.Client._Imports).Assembly);

// Add additional endpoints required by the Identity /Account Razor components.
app.MapAdditionalIdentityEndpoints();

app.MapControllers();

app.Run();
