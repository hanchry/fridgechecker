using fridgechecker.Models;
using fridgechecker.Utilities;

namespace fridgechecker.Services;

public interface IFoodService
{
    Task<IList<Food>> GetStorageFood(int storageId);
}
public class FoodService: IFoodService
{
    private IApiClientProxy _apiClientProxy;
    
    public FoodService(IApiClientProxy apiClientProxy)
    {
        _apiClientProxy = apiClientProxy;
    }

    public Task<IList<Food>> GetStorageFood(int storageId)
    {
        var result = _apiClientProxy.GetEntityAsync<IList<Food>>($"FoodsStorage?storageId={storageId}");
        return result;
    }
}