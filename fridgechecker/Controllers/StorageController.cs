using fridgechecker.Services;
using Microsoft.AspNetCore.Mvc;

namespace fridgechecker.Controllers;

public class StorageController:BaseController
{
    private readonly IStorageService _storageService;
    
    public StorageController(IStorageService storageService)
    {
        _storageService = storageService;
    }
    public async Task<IActionResult> Index(int id)
    {
        if (id != 0)
        {
            HouseId = id.ToString();
        }
        var storages =  await _storageService.GetStorages(Int32.Parse(HouseId));
        return View(storages);
    }
    public IActionResult Back()
    {
        return RedirectToAction("Index", "Household");
    }
    public IActionResult Storage(int storageId)
    {
        return RedirectToAction("Index", "Food", new {id = storageId});
    }
    public IActionResult Add()
    {
        return View();
    }
}