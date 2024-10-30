using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using QUICK_INVENTORY.Server.Data;
using QUICK_INVENTORY.Server.Data.Repositories;
using QUICK_INVENTORY.Server.Data.Repositories.Application;
using QUICK_INVENTORY.Server.Data.Services;
using QUICK_INVENTORY.Server.Data.Services.Application;
using QUICK_INVENTORY.Server.Domain;
using QUICK_INVENTORY.Server.Helpers.Repositories;
using QUICK_INVENTORY.Server.Helpers.Repositories.Application;
using QUICK_INVENTORY.Server.Helpers.Services;
using QUICK_INVENTORY.Server.Helpers.Services.Application;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string connectionString = builder.Configuration
    .GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("El string de conexión para la aplicación no se encontró o no existe.");

var loggerFactory = LoggerFactory.Create(builder =>
{
    builder
        .AddFilter((category, level) =>
            category == DbLoggerCategory.Database.Command.Name
            && level == LogLevel.Information)
        .AddConsole();
});

builder.Services
    .AddDbContext<ApplicationDbContext>(options =>
    {
        options.UseSqlServer(connectionString)
            .UseLoggerFactory(loggerFactory);
    });

builder.Services
    .AddDefaultIdentity<IdentidadUsuario>(options =>
    {
        options.SignIn.RequireConfirmedAccount = true;
    })
    .AddRoles<IdentidadRol>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

var identity = builder.Services.AddIdentityServer()
    .AddAspNetIdentity<IdentidadUsuario>()
    .AddOperationalStore<ApplicationDbContext>()
    .AddIdentityResources()
    .AddApiResources()
    .AddClients();

if (builder.Environment.IsDevelopment())
{
    identity.AddDeveloperSigningCredential();
}
else
{
    //var bytes = File.ReadAllBytes($"/var/ssl/private/{builder.Configuration["WEBSITE_LOAD_CERTIFICATES"]}.p12");
    //var certificate = new X509Certificate2(bytes);
    //identity.AddSigningCredentials(certificate);
}
//builder.Services
//    .AddIdentityServer()
//    .AddApiAuthorization<ApplicationUser, ApplicationDbContext>(options =>
//    {
//        options.IdentityResources["openid"].UserClaims.Add("role");
//        options.ApiResources.Single().UserClaims.Add("role");
//    });

builder.Services
    .AddAuthentication()
    .AddIdentityServerJwt();

builder.Services.AddScoped<IGeneralService, GeneralService>();
builder.Services.AddScoped<IProductoRegistrosService, ProductoRegistrosService>();

builder.Services.AddScoped<IGeneralRepository, GeneralRepository>();
builder.Services.AddScoped<IProductoRegistrosRepository, ProductoRegistrosRepository>();

builder.Services.AddScoped<IApplicationServices, ApplicationServices>();
builder.Services.AddScoped<IApplicationRepositories, ApplicationRepositories>();

builder.Services
    .AddHostedService<ApplicationDbContextSeed>();

builder.Services.AddControllers();

builder.Services
    .AddRazorPages();
builder.Services
    .AddControllersWithViews();
builder.Services
    .AddDatabaseDeveloperPageExceptionFilter();

builder.Services
    .AddEndpointsApiExplorer();
builder.Services
    .AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseWebAssemblyDebugging();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.UseIdentityServer();
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
