using Application.Services.Interfaces;
using Common.Extensions;
using Domain.Models.Creates;
using Domain.Models.Update;
using Infrastructure.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[Route("api/fish")]
[ApiController]
public class FishController : Controller
{
    private readonly IFishService _batchService;

    public FishController(IFishService batchService)
    {
        _batchService = batchService;
    }
    
    // GET
    [HttpGet]
    public async Task<IActionResult> GetFish()
    {
        return await _batchService.GetFish();
    }
    
    // GET
    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetFish([FromRoute] Guid id)
    {
        return await _batchService.GetFish(id);
    }
    
    // POST
    [HttpPost]
    [Authorize]
    public async Task<IActionResult> CreateFish([FromForm] FishCreateModel model)
    {
        var user = this.GetAuthenticatedUser();
        return await _batchService.CreateFish(user.Id, model);
    }
        
    // PUT
    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> UpdateFish([FromRoute] Guid id, [FromForm] FishUpdateModel model)
    {
        return await _batchService.UpdateFish(id, model);
    }
    
    // DELETE
    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> DeleteFish([FromRoute] Guid id)
    {
        return await _batchService.DeleteFish(id);
    }
}