using Ardalis.Result;
using QUICK_INVENTORY.Shared.Helpers.Interfaces.Services;
using QUICK_INVENTORY.Shared.Helpers.Interfaces.Services.Application;
using QUICK_INVENTORY.Shared.Models.TableModels;
using System.Text.Json;

namespace QUICK_INVENTORY.Shared.Helpers.Services.Application;

internal class InventarioService(IGeneralService generalService) : IInventarioService
{
    private readonly HttpClient _httpClient = generalService.HttpClient;
    private readonly JsonSerializerOptions _jsonSerializerOptions = generalService.JsonSerializerOptions;

    public async Task<Result<IEnumerable<InventarioDetalleTableModel>>> ConsultarDetallesCorteActual()
    {
        try
        {
            HttpResponseMessage
            httpRequestMessage = await _httpClient
                .GetAsync(requestUri: ApplicationApiEndpoints
                    .Inventario.Cortes.Actual);

            if (httpRequestMessage.IsSuccessStatusCode)
            {
                var response = JsonSerializer
                    .Deserialize<IEnumerable<InventarioDetalleTableModel>>(
                        utf8Json: await httpRequestMessage
                            .Content.ReadAsStreamAsync(),
                        options: _jsonSerializerOptions)
                    ?? throw new InvalidOperationException();

                return Result.Success(response);
            }
            else
            {
                return await httpRequestMessage.Content.GetHttpError();
            }
        }
        catch (Exception)
        {
            return Result.Error(errorMessage: GeneralErrors.ErrorInesperado);
        }
    }
}
