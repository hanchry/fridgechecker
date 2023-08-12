using Microsoft.AspNetCore.Mvc;

namespace fridgechecker.Controllers;

public class BaseController:Controller
{
    protected string GetUserToken()
    {
        return HttpContext.Session.GetString("token");
    }
}