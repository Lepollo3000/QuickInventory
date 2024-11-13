using Ardalis.Result;
using Microsoft.AspNetCore.WebUtilities;
using QUICK_INVENTORY.Client.Data.Services;
using QUICK_INVENTORY.Shared.Helpers.Interfaces.Services.Application;
using QUICK_INVENTORY.Shared.Models.Requests;
using QUICK_INVENTORY.Shared.Models.TableModels;
using System.Net.Http.Json;
using System.Text.Json;

namespace QUICK_INVENTORY.Shared.Helpers.Services.Application;

internal class ProductosMovimientosService(IGeneralService generalService) : IProductoMovimientosService
{
    private readonly HttpClient _httpClient = generalService.HttpClient;
    private readonly JsonSerializerOptions _jsonSerializerOptions = generalService.JsonSerializerOptions;

    public async Task<Result<IEnumerable<ProductoMovimientoTableModel>>> ConsultarProductoMovimientos(ProductoMovimientoSearchRequest searchRequest)
    {
        try
        {
            var parameters = new Dictionary<string, string?>
            {
                { nameof(searchRequest.MovimientoTipoId).ToLower(), ((int)searchRequest.MovimientoTipoId).ToString() }
            };

            HttpResponseMessage
            httpRequestMessage = await _httpClient
                .GetAsync(requestUri: QueryHelpers
                    .AddQueryString(
                        uri: ApplicationApiEndpoints
                            .Productos.Movimientos.Principal,
                        queryString: parameters));

            if (httpRequestMessage.IsSuccessStatusCode)
            {
                var response = JsonSerializer
                    .Deserialize<IEnumerable<ProductoMovimientoTableModel>>(
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
            return Result.Error(errorMessage: $"Error inesperado al intentar consultar los movimientos de producto.");
        }
    }
    public async Task<Result<ProductoMovimientoCreateRequest>> InsertarProductoMovimiento(ProductoMovimientoCreateRequest createRequest)
    {
        try
        {
            HttpResponseMessage
            httpRequestMessage = await _httpClient
                .PostAsJsonAsync(
                    requestUri: ApplicationApiEndpoints
                        .Productos.Movimientos.Principal,
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
            return Result.Error(errorMessage: $"Error inesperado al intentar registrar la {createRequest.MovimientoTipoId.GetDisplayName()} de producto.");
        }
    }
}
