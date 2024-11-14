using Ardalis.Result;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.WebUtilities;
using QUICK_INVENTORY.Client.Data.Services.Application;
using QUICK_INVENTORY.Shared.Helpers.Interfaces.Services;
using QUICK_INVENTORY.Shared.Models.Requests;
using QUICK_INVENTORY.Shared.Models.TableModels;
using System.Net.Http.Json;
using System.Text.Json;

namespace QUICK_INVENTORY.Shared.Helpers.Services.Application;

internal class ProductosService : IProductosService
{
    private readonly HttpClient _httpClient;
    private readonly JsonSerializerOptions _jsonSerializerOptions;

    public ProductosService(IGeneralService generalService, NavigationManager navigation)
    {
        _httpClient = generalService.HttpClient;
        _jsonSerializerOptions = generalService.JsonSerializerOptions;

        _httpClient.BaseAddress = new Uri(navigation.BaseUri);
    }
    public async Task<Result<ProductoTableModel>> ConsultarProducto(ProductoSearchRequest request)
    {
        try
        {
            var parameters = new Dictionary<string, string?>
            {
                { nameof(request.CodigoBarras).ToLower(), request.CodigoBarras },
                { nameof(request.BuscarIndividualmente).ToLower(), true.ToString() }
            };

            HttpResponseMessage
            httpRequestMessage = await _httpClient
                .GetAsync(requestUri: QueryHelpers
                    .AddQueryString(
                        uri: ApplicationApiEndpoints
                            .Productos.Principal,
                        queryString: parameters));

            if (httpRequestMessage.IsSuccessStatusCode)
            {
                var response = JsonSerializer
                    .Deserialize<IEnumerable<ProductoTableModel>>(
                        utf8Json: await httpRequestMessage
                            .Content.ReadAsStreamAsync(),
                        options: _jsonSerializerOptions)
                    ?? throw new InvalidOperationException();

                return Result.Success(response.First());
            }

            return Result.Error(errorMessage: GeneralErrors.ErrorInesperado);
        }
        catch (Exception)
        {
            return Result.Error(errorMessage: GeneralErrors.ErrorInesperado);
        }
    }

    public async Task<Result<IEnumerable<ProductoTableModel>>> ConsultarProductos()
    {
        try
        {
            HttpResponseMessage
            httpRequestMessage = await _httpClient
                .GetAsync(requestUri: ApplicationApiEndpoints
                    .Productos.Principal);

            if (httpRequestMessage.IsSuccessStatusCode)
            {
                var response = JsonSerializer
                    .Deserialize<IEnumerable<ProductoTableModel>>(
                        utf8Json: await httpRequestMessage
                            .Content.ReadAsStreamAsync(),
                        options: _jsonSerializerOptions)
                    ?? throw new InvalidOperationException();

                return Result.Success(response);
            }

            return Result.Error(errorMessage: GeneralErrors.ErrorInesperado);
        }
        catch (Exception)
        {
            return Result.Error(errorMessage: GeneralErrors.ErrorInesperado);
        }
    }

    public async Task<Result<ProductoTableModel>> InsertarProducto(ProductoCreateRequest request)
    {
        try
        {
            HttpResponseMessage
            httpRequestMessage = await _httpClient
                .PostAsJsonAsync(
                    requestUri: ApplicationApiEndpoints
                        .Productos.Principal,
                    value: request);

            if (httpRequestMessage.IsSuccessStatusCode)
            {
                var response = JsonSerializer
                    .Deserialize<ProductoTableModel>(
                        utf8Json: await httpRequestMessage
                            .Content.ReadAsStreamAsync(),
                        options: _jsonSerializerOptions)
                    ?? throw new InvalidOperationException();

                return Result.Success(response);
            }

            return Result.Error(errorMessage: GeneralErrors.ErrorInesperado);
        }
        catch (Exception)
        {
            return Result.Error(errorMessage: GeneralErrors.ErrorInesperado);
        }
    }
}
