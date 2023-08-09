using AutoMapper;
using fridgechecker.Legacy;
using fridgechecker.Legacy.Entities;
using fridgechecker.Legacy.Models;
using Microsoft.EntityFrameworkCore;

namespace fridgechecker.Service;

public interface IHouseHoldService
{
    Task<HouseHoldDB> GetHouseHold(int id);
    Task<IList<HouseHoldDB>> GetHouseHolds(int userId);
    Task<HouseHoldDB> CreateHouseHold(HouseHoldDB houseHold);
    Task AddUserToHouseHold(int userId, int houseHoldId);
    Task RemoveHouseHold(int id);
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

    public async Task<IList<HouseHoldDB>> GetHouseHolds(int userId)
    {
        var userHouseHolds = _legacy.UserHouseHolds.Where(uh => uh.UserId == userId);
        var houseHolds = await _legacy.HouseHolds.Where(h => userHouseHolds.Any(uh => uh.HouseHoldId == h.Id)).ToListAsync();
        return _mapper.Map<IList<HouseHoldDB>>(houseHolds);
    }

    public async Task<HouseHoldDB> CreateHouseHold(HouseHoldDB houseHold)
    {
        var userHouseHold = await _legacy.HouseHolds.AddAsync(_mapper.Map<HouseHold>(houseHold));
        _legacy.SaveChanges();
        return _mapper.Map<HouseHoldDB>(userHouseHold.Entity);
    }

    public async Task AddUserToHouseHold(int userId, int houseHoldId)
    {
        var user  = await _legacy.Users.FirstOrDefaultAsync(u => u.Id == userId);
        var house = await _legacy.HouseHolds.FirstOrDefaultAsync(h => h.Id == houseHoldId);
        if (user == null || house == null)
        {
            throw new Exception("User or HouseHold not found");
        }
        else
        {
            var userHouseHold = await _legacy.UserHouseHolds.AddAsync(new UserHouseHold
            {
                UserId = userId,
                HouseHoldId = houseHoldId
            });
            await _legacy.SaveChangesAsync();
        }
    }

    public async Task RemoveHouseHold(int id)
    {
        _legacy.UserHouseHolds.RemoveRange(_legacy.UserHouseHolds.Where(uh => uh.HouseHoldId == id));
        _legacy.HouseHolds.Remove(new HouseHold {Id = id});
        await _legacy.SaveChangesAsync();
    }
}