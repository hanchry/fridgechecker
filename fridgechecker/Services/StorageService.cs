using fridgechecker.Models;
using fridgechecker.Utilities;

namespace fridgechecker.Services;

public interface IStorageService
{
    Task<IList<Storage>> GetStorages(int houseHoldId);
}
public class StorageService: IStorageService
{
    private IApiClientProxy _apiClientProxy;
    
    public StorageService(IApiClientProxy apiClientProxy)
    {
        _apiClientProxy = apiClientProxy;
    }

    public async Task<IList<Storage>> GetStorages(int houseHoldId)
    {
        var result = await _apiClientProxy.GetEntityAsync<IList<Storage>>($"Storages?houseHoldId={houseHoldId}");
        return result;
    }
}