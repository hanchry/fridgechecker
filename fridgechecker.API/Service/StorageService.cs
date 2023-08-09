using AutoMapper;
using fridgechecker.Legacy;
using fridgechecker.Legacy.Entities;
using fridgechecker.Legacy.Models;
using Microsoft.EntityFrameworkCore;

namespace fridgechecker.Service;

public interface IStorageService
{
    Task<IList<Storage>> GetStorages(int houseHoldId);
    Task<Storage> AddStorage(StorageDB storage);
    Task RemoveStorage(int id);
}
public class StorageService: IStorageService
{
    private readonly FridgeLegacyContext _legacy;
    private readonly IMapper _mapper;

    public StorageService(FridgeLegacyContext legacy, IMapper mapper)
    {
        _legacy = legacy;
        _mapper = mapper;
    }

    public async Task<IList<Storage>> GetStorages(int houseHoldId)
    {
        var storages = await _legacy.Storages.Where(s => s.HouseHoldId == houseHoldId).ToListAsync();
        return _mapper.Map<IList<Storage>>(storages);
    }

    public async Task<Storage> AddStorage(StorageDB storage)
    {
        var storageEntity = await _legacy.Storages.AddAsync(_mapper.Map<Storage>(storage));
        await _legacy.SaveChangesAsync();
        return _mapper.Map<Storage>(storageEntity.Entity);
    }

    public Task RemoveStorage(int id)
    {
        _legacy.Storages.Remove(new Storage {Id = id});
        return _legacy.SaveChangesAsync();
    }
}