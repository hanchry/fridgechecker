using fridgechecker.Models;
using fridgechecker.Utilities;

namespace fridgechecker.Services;

public interface IFoodService
{
    Task<IList<Food>> GetStorageFood(int storageId);
    Task<Food> CreateFood(Food food);
    Task DeleteFood(int id);
}

public class FoodService : IFoodService
{
    private IApiClientProxy _apiClientProxy;

    public FoodService(IApiClientProxy apiClientProxy)
    {
        _apiClientProxy = apiClientProxy;
    }

    public async Task<IList<Food>> GetStorageFood(int storageId)
    {
        var result = await _apiClientProxy.GetEntityAsync<IList<Food>>($"FoodsStorage?storageId={storageId}");
        return result;
    }
    public async Task<Food> CreateFood(Food food)
    {
        var result = await _apiClientProxy.PostEntityAsync<Food>("Food", food);
        return result;
    }

    public async Task DeleteFood(int id)
    {
        var result = await _apiClientProxy.DeleteEntityAsync<Food>($"Food?id={id}","1");
    }
}