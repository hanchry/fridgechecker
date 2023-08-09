using AutoMapper;
using fridgechecker.Legacy;
using fridgechecker.Legacy.Entities;
using fridgechecker.Legacy.Models;
using Microsoft.EntityFrameworkCore;

namespace fridgechecker.Service;

public interface IHouseHoldService
{
    Task<HouseHoldDB> GetHouseHold(int id);
}

public class HouseHoldService: IHouseHoldService
{
    private readonly FridgeLegacyContext _legacy;
    private readonly IMapper _mapper;

    public HouseHoldService(FridgeLegacyContext legacy, IMapper mapper)
    {
        _legacy = legacy;
        _mapper = mapper;
    }
    public async Task<HouseHoldDB> GetHouseHold(int id)
    {
        var houseHold = await _legacy.HouseHolds.FirstOrDefaultAsync(h => h.Id == id);
        return _mapper.Map<HouseHoldDB>(houseHold);
    }
}