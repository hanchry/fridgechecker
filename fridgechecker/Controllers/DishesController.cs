using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace fridgechecker.Controllers;

[Authorize]
public class DishesController:BaseController
{
    public IActionResult Index()
    {
        return View();
    }
}