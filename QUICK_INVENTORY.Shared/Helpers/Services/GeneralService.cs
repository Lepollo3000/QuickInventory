using QUICK_INVENTORY.Shared.Helpers.Interfaces.Services;
using System.Text.Json;

namespace QUICK_INVENTORY.Client.Helpers.Services;

internal class GeneralService(HttpClient httpClient) : IGeneralService
{
    public HttpClient HttpClient { get => httpClient; }
    public JsonSerializerOptions JsonSerializerOptions { get => new() { PropertyNameCaseInsensitive = true }; }
}
