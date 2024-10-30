using System.Text.Json;

namespace QUICK_INVENTORY.Client.Data.Services;

public interface IGeneralService
{
    HttpClient HttpClient { get; }
    JsonSerializerOptions JsonSerializerOptions { get; }
}
