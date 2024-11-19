using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MimeKit;
using QUICK_INVENTORY.Data.Repositories;
using QUICK_INVENTORY.Data.Services;
using QUICK_INVENTORY.Domain;
using QUICK_INVENTORY.Shared.Helpers;
using QUICK_INVENTORY.Shared.Models.Requests;
using QUICK_INVENTORY.Shared.Models.TableModels;
using SendGrid.Helpers.Mail;
using SendGrid;

namespace QUICK_INVENTORY.Controllers;

[Authorize]
[ApiController]
[Route(ApplicationApiEndpoints.Productos.Principal)]
public class ProductosController(IApplicationServices services, IConfiguration configuration, IApplicationRepositories repositories, UserManager<IdentidadUsuario> roleManager) : ControllerBase
{
    private readonly IApplicationServices _services = services;
    private readonly IApplicationRepositories _repositories = repositories;
    private readonly UserManager<IdentidadUsuario> _userManager = roleManager;

    private readonly string _emailSendKey = configuration
        .GetSection("MailSettings").GetValue<string>("SendKey") ?? string.Empty;

    //private async Task EnviarEmail(string mensaje, IdentidadUsuario usuario)
    //{
    //    using var message = new MimeMessage();
    //    message.From.Add(new MailboxAddress(
    //        "QUICK INVENTORY",
    //        "josemanuel.lepe@gmail.com"
    //    ));
    //    message.To.Add(new MailboxAddress(
    //        $"{usuario.UserName}",
    //        $"{usuario.Email}"
    //    ));
    //    message.Subject = "Sending with Twilio SendGrid is Fun";
    //    var bodyBuilder = new BodyBuilder
    //    {
    //        TextBody = "and easy to do anywhere, especially with C#",
    //        HtmlBody = "and easy to do anywhere, <b>especially with C#</b>"
    //    };
    //    message.Body = bodyBuilder.ToMessageBody();

    //    using var client = new SmtpClient();
    //    // SecureSocketOptions.StartTls force a secure connection over TLS
    //    await client.ConnectAsync("smtp.sendgrid.net", 587, SecureSocketOptions.StartTls);
    //    await client.AuthenticateAsync(
    //        userName: "apikey", // the userName is the exact string "apikey" and not the API key itself.
    //        password: _emailSendKey // password is the API key
    //    );

    //    Console.WriteLine("Sending email");
    //    await client.SendAsync(message);
    //    Console.WriteLine("Email sent");

    //    await client.DisconnectAsync(true);
    //}

    //private async Task EnviarEmail(string mensaje, IdentidadUsuario usuario)
    //{
    //    var client = new SendGridClient(_emailSendKey);
    //    var from_email = new EmailAddress("josemanuel.lepe@gmail.com", "Example User");
    //    var subject = "Sending with Twilio SendGrid is Fun";
    //    var to_email = new EmailAddress(usuario.Email, "Example User");
    //    var plainTextContent = "and easy to do anywhere, even with C#";
    //    var htmlContent = "<strong>and easy to do anywhere, even with C#</strong>";
    //    var msg = MailHelper.CreateSingleEmail(from_email, to_email, subject, plainTextContent, htmlContent);
    //    var response = await client.SendEmailAsync(msg).ConfigureAwait(false);
    //}

    [HttpGet("warnings/{productoId}")]
    public async Task<IActionResult> WarningsProducto(int productoId)
    {
        try
        {
            Producto producto = await _repositories.General.Context.Productos
                .Where(model => !model.EstaEliminado)
                .Where(model => model.Id == productoId)
                .FirstOrDefaultAsync()
                ?? throw new ArgumentException("El producto ingresado no se encontró o no existe.");

            string? error = null;

            if (producto.Stock <= producto.StockMinimo)
            {
                error = $"El producto ha alcanzado su nivel de stock mínimo, se recomienda ordenar más de éste.";
            }
            else if (producto.Stock >= producto.StockMaximo)
            {
                error = $"El producto ha alcanzado su nivel de stock máximo, no se recomienda ordenar más de éste.";
            }

            if (error != null)
            {
                //var administradores = await _userManager
                //    .GetUsersInRoleAsync(roleName: "Administrador");

                //foreach (var administrador in administradores)
                //{
                //    if (administrador != null)
                //    {
                //        try
                //        {
                //            await EnviarEmail(
                //                mensaje: error,
                //                usuario: administrador);
                //        }
                //        catch (Exception ex)
                //        {
                //        }
                //    }
                //}

                return BadRequest(error);
            }

            return NoContent();
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpGet]
    public async Task<IActionResult> ObtenerProductos([FromQuery] ProductoSearchRequest searchRequest)
    {
        try
        {
            var tableModelList = await _services
                .Productos.ConsultarProductos(
                    searchRequest: searchRequest);

            return Ok(tableModelList);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> InsertarProducto([FromBody] ProductoCreateRequest request)
    {
        try
        {
            IdentidadUsuario usuario = await _services
                .GeneralService.ConsultarUsuario(User);

            Producto producto = await _services
                .Productos.InsertarProducto(
                    request: request,
                    usuario: usuario);

            InventarioCorte? corteActual = await _repositories
                .Inventario.ConsultarInventarioCorteActual();

            if (corteActual == null)
            {
                corteActual = new(usuario: usuario);

                _repositories.General.Context.Add(corteActual);
            }

            InventarioCorteDetalle corteDetalle = new(
                producto: producto,
                corte: corteActual,
                usuario: usuario);

            _repositories.General.Context.Add(corteDetalle);

            await _repositories.General.Context.SaveChangesAsync();

            ProductoTableModel tableModel = new()
            {
                CodigoBarras = producto.CodigoBarras,
                Locacion = producto.Locacion,
                Nombre = producto.Nombre,
                Descripcion = producto.Descripcion,
                StockMedidaId = producto.StockMedidaId,
                StockMinimo = producto.StockMinimo,
                StockMaximo = producto.StockMaximo,
                Stock = producto.Stock
            };

            return Ok(tableModel);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}
