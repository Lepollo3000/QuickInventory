using Ardalis.Result;

namespace QUICK_INVENTORY.Shared.Helpers;

public static class GeneralExtensions
{
    public static async Task<Result> GetHttpError(this HttpContent httpRequestContent)
    {
        var response = await httpRequestContent.ReadAsStringAsync();

        return Result.Error(errorMessage: response);
    }
}
