using fridgechecker.Models;
using fridgechecker.Utilities;

namespace fridgechecker.Services;

public interface IHouseHoldService
{
    Task<IList<HouseHold>> GetHouseHolds(int userId);
}
public class HouseHoldService: IHouseHoldService
{
    private IApiClientProxy _apiClientProxy;
    
    public HouseHoldService(IApiClientProxy apiClientProxy)
    {
        _apiClientProxy = apiClientProxy;
    }

    public async Task<IList<HouseHold>> GetHouseHolds(int userId)
    {
        var result = await _apiClientProxy.GetEntityAsync<IList<HouseHold>>($"HouseHolds?userId={userId}");
        return result;
    }
}