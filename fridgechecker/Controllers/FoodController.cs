using fridgechecker.Models;
using fridgechecker.Services;
using Microsoft.AspNetCore.Mvc;

namespace fridgechecker.Controllers;

public class FoodController:BaseController
{
    private readonly IFoodService _foodService;

    public FoodController(IFoodService foodService)
    {
        _foodService = foodService;
    }
    public async Task<IActionResult> Index(int id)
    {
        if (id != 0)
        {
            StorageId = id.ToString();
        }
        var foods = await _foodService.GetStorageFood(int.Parse(StorageId));
        return View(foods);
    }
    public IActionResult Back()
    {
        return RedirectToAction("Index", "Storage");
    }
    public IActionResult ChooseIcon()
    {
        return RedirectToAction("Index", "Icons");
    }
    public IActionResult Add(String icon)
    {
        var food = new Food();
        food.Image = icon;
        return View(food);
    }
    public async Task<IActionResult> AddFood(Food food)
    {
        Console.WriteLine(food.Image);
        food.StorageId = int.Parse(StorageId);
        await _foodService.CreateFood(food);
        return RedirectToAction("Index");
    }
    public async Task<IActionResult> Delete(int foodId)
    {
        await _foodService.DeleteFood(foodId);
        return RedirectToAction("Index");
    }
}