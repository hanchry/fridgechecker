using AutoMapper;
using fridgechecker.Legacy;
using fridgechecker.Legacy.Entities;
using fridgechecker.Legacy.Models;
using Microsoft.EntityFrameworkCore;

namespace fridgechecker.Service;

public interface IFoodService
{
    Task<Food> GetFoodAsync(int id);
    Task<IList<FoodDB>> GetStorageFoodsAsync(int storageId);
    Task<IList<FoodDB>> GetDishFoodsAsync(int dishId);
    Task<FoodDB> CreateFoodAsync(FoodDB food);
    Task UpdateFoodAsync(FoodDB food);
    Task DeleteFoodAsync(int id);   
}
public class FoodService: IFoodService
{
    private readonly FridgeLegacyContext _legacy;
    private readonly IMapper _mapper;

    public FoodService(FridgeLegacyContext legacy, IMapper mapper)
    {
        _legacy = legacy;
        _mapper = mapper;
    }
    
    public async Task<Food> GetFoodAsync(int id)
    {
        var food = await _legacy.Foods.FirstOrDefaultAsync(f => f.Id == id);
        return _mapper.Map<Food>(food);
    }

    public async Task<IList<FoodDB>> GetStorageFoodsAsync(int storageId)
    {
        var foods = await _legacy.Foods.Where(f => f.StorageId == storageId).ToListAsync();
        return _mapper.Map<IList<FoodDB>>(foods);
    }

    public async Task<IList<FoodDB>> GetDishFoodsAsync(int dishId)
    {
        var DishFoods = await _legacy.DishFoods.Where(df => df.DishId == dishId).ToListAsync();
        var foods = await _legacy.Foods.Where(f => DishFoods.Any(df => df.FoodId == f.Id)).ToListAsync();
        return _mapper.Map<IList<FoodDB>>(foods);
    }

    public async Task<FoodDB> CreateFoodAsync(FoodDB food)
    {
        var foodEntity = await _legacy.Foods.AddAsync(_mapper.Map<Food>(food));
        await _legacy.SaveChangesAsync();
        return _mapper.Map<FoodDB>(foodEntity.Entity);
    }

    public async Task UpdateFoodAsync(FoodDB food)
    {
        _legacy.Foods.Update(_mapper.Map<Food>(food));
        await _legacy.SaveChangesAsync();
    }

    public async Task DeleteFoodAsync(int id)
    {
        _legacy.Foods.Remove(this.GetFoodAsync(id).Result);
        await _legacy.SaveChangesAsync();
    }
}