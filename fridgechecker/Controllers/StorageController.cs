using Microsoft.AspNetCore.Mvc;

namespace fridgechecker.Controllers;

public class StorageController:BaseController
{
    public IActionResult Index()
    {
        return View();
    }
    public IActionResult Back()
    {
        return RedirectToAction("Index", "Household");
    }
    public IActionResult Storage()
    {
        return RedirectToAction("Index", "Food");
    }
}