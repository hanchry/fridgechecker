using Microsoft.AspNetCore.Mvc;

namespace fridgechecker.Controllers;

public class BaseController:Controller
{
    protected string GetUserToken()
    {
        return HttpContext.Session.GetString("token");
    }
    protected string GetUserId()
    {
        return HttpContext.Session.GetString("userId");
    }

    public string HouseId
    {
        get => HttpContext.Session.GetString("houseId");
        set => HttpContext.Session.SetString("houseId", value);
    }
}