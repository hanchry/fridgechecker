using fridgechecker.Legacy.Models;
using fridgechecker.Service;
using Microsoft.AspNetCore.Mvc;

namespace fridgechecker.Controllers;

[Route("api/")]
[ApiController]
public class FoodController: Controller
{
    private readonly IFoodService _foodService;
    
    public FoodController(IFoodService foodService)
    {
        _foodService = foodService;
    }
    
    [HttpGet("FoodsStorage", Name = nameof(FoodsStorage))]
    public async Task<IActionResult> FoodsStorage(int storageId)
    {
        var foods = await _foodService.GetStorageFoodsAsync(storageId);
        return Ok(foods);
    }
    [HttpGet("FoodsDishes", Name = nameof(FoodsDishes))]
    public async Task<IActionResult> FoodsDishes(int dishId)
    {
        var foods = await _foodService.GetDishFoodsAsync(dishId);
        return Ok(foods);
    }
    [HttpPost("Food", Name = nameof(Food))]
    public async Task<IActionResult> Food(FoodDB food)
    {
        
        var foodResult = await _foodService.CreateFoodAsync(food);
        return Ok(foodResult);
    }
    [HttpPut("Food", Name = nameof(Food))]
    public async Task<IActionResult> Food(FoodDB food, int id)
    {
        await _foodService.UpdateFoodAsync(food);
        return Ok();
    }
    [HttpDelete("Food", Name = nameof(Food))]
    public async Task<IActionResult> DeleteFood(int id)
    {
        await _foodService.DeleteFoodAsync(id);
        return Ok();
    }
    
    
}