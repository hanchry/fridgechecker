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
        var foods = await _foodService.GetStorageFood(id);
        return View(foods);
    }
    public IActionResult Back()
    {
        return RedirectToAction("Index", "Storage");
    }
    public IActionResult Add()
    {
        return View();
    }
}