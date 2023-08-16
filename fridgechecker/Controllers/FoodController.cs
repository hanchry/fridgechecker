using Microsoft.AspNetCore.Mvc;

namespace fridgechecker.Controllers;

public class FoodController:BaseController
{
    public IActionResult Index()
    {
        return View();
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