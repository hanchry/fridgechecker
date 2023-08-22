using System.Security.Claims;
using fridgechecker.Models;
using fridgechecker.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace fridgechecker.Controllers;

[Authorize]
public class HouseHoldController:BaseController
{
    private readonly IHouseHoldService _houseHoldService;
    public HouseHoldController(IHouseHoldService houseHoldService)
    {
        _houseHoldService = houseHoldService;
    }
    public async Task<IActionResult> Index()
    {
        var userId = "1";
        HttpContext.Session.SetString("userId", userId);
        
        // Console.WriteLine("token "+GetUserToken());
        
        var houseHolds = await _houseHoldService.GetHouseHolds(Int32.Parse(GetUserId()));
        return View(houseHolds);
    }
    public IActionResult HouseHold(int houseHoldId)
    {
        return RedirectToAction("Index","Storage",new {id = houseHoldId});
    }
    public IActionResult Logout()
    {
        return RedirectToAction("Index","Home");
    }
    public IActionResult Add()
    {
        return View();
    }
}