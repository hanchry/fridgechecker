using fridgechecker.Service;
using Microsoft.AspNetCore.Mvc;

namespace fridgechecker.Controllers;

[Route("api/")]
[ApiController]
public class HouseHoldController : Controller
{
    private readonly IHouseHoldService _houseHoldService;
    
    public HouseHoldController(IHouseHoldService houseHoldService)
    {
        _houseHoldService = houseHoldService;
    }
    
    
    [HttpGet("HouseHolds", Name = nameof(HouseHolds))]
    public async Task<IActionResult> HouseHolds(int userId)
    {
        var houseHolds = await _houseHoldService.GetHouseHolds(userId);
        return Ok("nice");
    }
    [HttpGet("HouseHold", Name = nameof(HouseHold))]
    public async Task<IActionResult> HouseHold(int id)
    {
        var houseHold = await _houseHoldService.GetHouseHold(id);
        return Ok(houseHold);
    }
    
}