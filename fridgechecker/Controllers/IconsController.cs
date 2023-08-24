using Microsoft.AspNetCore.Mvc;

namespace fridgechecker.Controllers;

public class IconsController:BaseController
{
    public IActionResult Index()
    {
        return View();
    }
    
    public IActionResult Back()
    {
        return RedirectToAction("Add", "Food");
    }
    public IActionResult ChooseIcon(string icon)
    {
        return RedirectToAction("Add", "Food", new {icon = icon});
    }
}