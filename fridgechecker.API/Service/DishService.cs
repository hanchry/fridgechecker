using AutoMapper;
using fridgechecker.Legacy;
using fridgechecker.Legacy.Entities;
using fridgechecker.Legacy.Models;
using Microsoft.EntityFrameworkCore;

namespace fridgechecker.Service;

public interface IDishService
{
    Task<DishDB> GetDishAsync(int id);
    Task<IList<DishDB>> GetDishesAsync(int userId);
    Task<DishDB> CreateDishAsync(int userId,DishDB dish);
    Task AddFoodToDishAsync(int dishId, int foodId, int amount, string amountType);
    Task UpdateFoodInDishAsync(int dishId, int foodId, int amount, string amountType);
    Task RemoveFoodFromDishAsync(int dishId, int foodId);
    Task UpdateDishAsync(DishDB dish);
    Task DeleteDishAsync(int id);
}
public class DishService: IDishService
{
    private readonly FridgeLegacyContext _legacy;
    private readonly IMapper _mapper;

    public DishService(FridgeLegacyContext legacy, IMapper mapper)
    {
        _legacy = legacy;
        _mapper = mapper;
    }

    public async Task<DishDB> GetDishAsync(int id)
    {
        var dish = await _legacy.Dishes.FirstOrDefaultAsync(d => d.Id == id);
        return _mapper.Map<DishDB>(dish);
    }

    public async Task<IList<DishDB>> GetDishesAsync(int userId)
    {
        var userDishes = await _legacy.UserDishes.Where(ud => ud.UserId == userId).ToListAsync();
        var dishes = await _legacy.Dishes.Where(d => userDishes.Any(ud => ud.DishId == d.Id)).ToListAsync();
        return _mapper.Map<IList<DishDB>>(dishes);
    }

    public async Task<DishDB> CreateDishAsync(int userId,DishDB dish)
    {
        var dishResult = _legacy.Dishes.Add(_mapper.Map<Dish>(dish));
        _legacy.UserDishes.Add(new UserDish { UserId = userId, DishId = dish.Id });
        await _legacy.SaveChangesAsync();
        return _mapper.Map<DishDB>(dishResult.Entity);
    }

    public async  Task AddFoodToDishAsync(int dishId, int foodId, int amount, string amountType)
    {
        var dish = _legacy.Dishes.FirstOrDefault(d => d.Id == dishId);
        var food = _legacy.Foods.FirstOrDefault(f => f.Id == foodId);
        if(dish == null || food == null)
        {
            throw new Exception("Dish or food not found");
        }
        else
        {
            _legacy.DishFoods.Add(new DishFood { DishId = dishId, FoodId = foodId, Amount = amount, AmountType = amountType });
            await _legacy.SaveChangesAsync();
        }
    }

    public async Task UpdateFoodInDishAsync(int dishId, int foodId, int amount, string amountType)
    {
        _legacy.DishFoods.Update(new DishFood { DishId = dishId, FoodId = foodId, Amount = amount, AmountType = amountType });
        await _legacy.SaveChangesAsync();
    }

    public async Task RemoveFoodFromDishAsync(int dishId, int foodId)
    {
        var dishFood = await _legacy.DishFoods.FirstOrDefaultAsync(df => df.DishId == dishId && df.FoodId == foodId);
        if(dishFood == null)
        {
            throw new Exception("DishFood not found");
        }
        else
        {
            _legacy.DishFoods.Remove(dishFood);
            await _legacy.SaveChangesAsync();
        }
    }

    public Task UpdateDishAsync(DishDB dish)
    {
        _legacy.Dishes.Update(_mapper.Map<Dish>(dish));
        return _legacy.SaveChangesAsync();
    }

    public async Task DeleteDishAsync(int id)
    {
        _legacy.Dishes.Remove(new Dish { Id = id });
        await _legacy.SaveChangesAsync();
    }
}