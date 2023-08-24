using fridgechecker.Legacy.Models;
using fridgechecker.Service;
using Microsoft.AspNetCore.Mvc;

namespace fridgechecker.Controllers;

[Route("api/")]
[ApiController]
public class StorageController: Controller
{
    private readonly IStorageService _storageService;
    
    public StorageController(IStorageService storageService)
    {
        _storageService = storageService;
    }
    
    [HttpGet("Storages", Name = nameof(Storages))]
    public async Task<IActionResult> Storages(int houseHoldId)
    {
        var storages = await _storageService.GetStorages(houseHoldId);
        return Ok(storages);
    }
    [HttpPost("Storage", Name = nameof(Storage))]
    public async Task<IActionResult> Storage(StorageDB storage)
    {
        var storageResult = await _storageService.AddStorage(storage);
        return Ok(storageResult);
    }
    [HttpDelete("Storage", Name = nameof(Storage))]
    public async Task<IActionResult> DeleteStorage(int id)
    {
        await _storageService.RemoveStorage(id);
        return Ok();
    }
}