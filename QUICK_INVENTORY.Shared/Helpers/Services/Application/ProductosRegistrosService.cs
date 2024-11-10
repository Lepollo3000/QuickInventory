using Ardalis.Result;
using QUICK_INVENTORY.Client.Data.Services;
using QUICK_INVENTORY.Shared.Helpers;
using QUICK_INVENTORY.Shared.Helpers.Interfaces.Services.Application;
using QUICK_INVENTORY.Shared.Models.Requests;
using System.Net.Http.Json;
using System.Text.Json;

namespace QUICK_INVENTORY.Client.Helpers.Services.Application;

internal class ProductosRegistrosService(IGeneralService generalService) : IProductoRegistrosService
{
    private readonly HttpClient _httpClient = generalService.HttpClient;
    private readonly JsonSerializerOptions _jsonSerializerOptions = generalService.JsonSerializerOptions;

    public async Task<Result<ProductoMovimientoCreateRequest>> InsertarProductoRegistro(ProductoMovimientoCreateRequest createRequest)
    {
        try
        {
            HttpResponseMessage
            httpRequestMessage = await _httpClient
                .PostAsJsonAsync(
                    requestUri: ApplicationApiEndpoints
                        .Productos.Movimientos.Crear,
                    value: createRequest);

            if (httpRequestMessage.IsSuccessStatusCode)
            {
                var response = JsonSerializer
                    .Deserialize<ProductoMovimientoCreateRequest>(
                        utf8Json: await httpRequestMessage
                            .Content.ReadAsStreamAsync(),
                        options: _jsonSerializerOptions)
                    ?? throw new InvalidOperationException();

                return Result.Success(response);
            }

            throw new InvalidOperationException();
        }
        catch (Exception)
        {
            return Result.Error(errorMessage: $"Error inesperado al intentar registrar la {createRequest.RegistroTipoId.GetDisplayName()} de producto.");
        }
    }
}
