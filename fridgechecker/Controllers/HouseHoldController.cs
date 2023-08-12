using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace fridgechecker.Controllers;

[Authorize]
public class HouseHoldController:BaseController
{
    public IActionResult Index()
    {
        return View();
    }
    public IActionResult HouseHold()
    {
        return RedirectToAction("Index","Storage");
    }
    public IActionResult Logout()
    {
        return RedirectToAction("Index","Home");
    }
    public IActionResult Back()
    {
        return RedirectToAction("Index");
    }
    public IActionResult Add()
    {
        return View();
    }
}