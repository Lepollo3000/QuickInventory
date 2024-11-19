using CurrieTechnologies.Razor.SweetAlert2;
using MudBlazor;

namespace QUICK_INVENTORY.Shared.Helpers;

public static class SweetAlertExtensions
{
    public static async Task<SweetAlertResult> AlertaExito(this SweetAlertService sweetAlert, MudTheme theme, string mensaje, Func<Task> accionAlCerrar)
    {
        return await sweetAlert.FireAsync(new SweetAlertOptions
        {
            Icon = SweetAlertIcon.Success,
            Title = "Operación exitosa",
            Html = $@"<div class=""mx-4 my-3"" style=""text-align: justify"">
                    {mensaje}
                </div>",
            ShowConfirmButton = true,
            ConfirmButtonColor = theme.PaletteLight.Primary.Value,
            ConfirmButtonText = "Entendido",
            DidClose = new SweetAlertCallback(accionAlCerrar)
        });
    }

    public static async Task<SweetAlertResult> AlertaProcesoEnCarga(this SweetAlertService sweetAlert, MudTheme theme, Func<Task> accionPorRealizar)
    {
        return await sweetAlert.FireAsync(new SweetAlertOptions
        {
            Title = "Cargando... Espere",
            Html = $@"<div class=""mx-4 my-5"" style=""text-align: center"">
                    <div class=""spinner-border"" style=""color: {theme.PaletteLight.Primary.Value}!important;""></div>
                </div>",
            ShowConfirmButton = false,
            ShowCancelButton = false,
            AllowEscapeKey = false,
            AllowEnterKey = false,
            AllowOutsideClick = false,
            DidOpen = new SweetAlertCallback(accionPorRealizar)
        });
    }

    public static async Task<SweetAlertResult> AlertaAdvertencia(this SweetAlertService sweetAlert, MudTheme theme, string mensaje, Func<Task>? accionAlCerrar = null)
    {
        return await sweetAlert.FireAsync(new SweetAlertOptions
        {
            Icon = SweetAlertIcon.Warning,
            Title = "Para tomar en cuenta",
            Html = $@"<div class=""mx-4 my-3"" style=""text-align: justify"">
                    {mensaje}
                </div>",
            ShowConfirmButton = true,
            ConfirmButtonColor = theme.PaletteLight.Primary.Value,
            ConfirmButtonText = "Entendido",
            DidClose = new SweetAlertCallback(accionAlCerrar)
        });
    }

    public static async Task<SweetAlertResult> AlertaError(this SweetAlertService sweetAlert, MudTheme theme, string mensaje, Func<Task>? accionAlCerrar = null)
    {
        return await sweetAlert.FireAsync(new SweetAlertOptions
        {
            Icon = SweetAlertIcon.Error,
            Title = "Algo salió mal",
            Html = $@"<div class=""mx-4 my-3"" style=""text-align: justify"">
                    {mensaje}
                </div>",
            ShowConfirmButton = true,
            ConfirmButtonColor = theme.PaletteLight.Primary.Value,
            ConfirmButtonText = "Entendido",
            DidClose = new SweetAlertCallback(accionAlCerrar)
        });
    }

    public static async Task<SweetAlertResult> AlertaErrorInesperado(this SweetAlertService sweetAlert, MudTheme theme)
    {
        return await sweetAlert.AlertaError(theme: theme, mensaje: GeneralErrors.ErrorInesperado);
    }
}
