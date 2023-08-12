using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using fridgechecker.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace fridgechecker.Controllers;


public class HomeController : BaseController
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        if (User.Identity.IsAuthenticated)
        {
            return RedirectToAction("Index", "HouseHold");
        }
        return View();
    }

    public async Task<IActionResult> GetStarted()
    {
        Console.WriteLine(1);
        var token = "123";
        var claims = new List<Claim>()
        {
            new Claim(ClaimTypes.Role, "User"),
        };
        var identity = new ClaimsIdentity(claims, "User claims");
        var principal = new ClaimsPrincipal(new[] {identity});

        //stores all userclaims to the users cookiesession
        await HttpContext.SignInAsync(principal);
        HttpContext.Session.SetString("token", token);
        
        return RedirectToAction("Index", "HouseHold");
    }
}