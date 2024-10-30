using QUICK_INVENTORY.Client.Data.Services;
using System.Text.Json;

namespace QUICK_INVENTORY.Client.Helpers.Services;

public class GeneralService(HttpClient httpClient) : IGeneralService
{
    public HttpClient HttpClient { get => httpClient; }
    public JsonSerializerOptions JsonSerializerOptions { get => new() { PropertyNameCaseInsensitive = true }; }
}
