using System.Text.Json;

namespace QUICK_INVENTORY.Shared.Helpers.Interfaces.Services;

internal interface IGeneralService
{
    HttpClient HttpClient { get; }
    JsonSerializerOptions JsonSerializerOptions { get; }
}
