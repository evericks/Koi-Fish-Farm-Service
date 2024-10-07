using Application.Services.Interfaces;
using Common.Extensions;
using Domain.Models.Creates;
using Domain.Models.Update;
using Infrastructure.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[Route("api/batches")]
[ApiController]
public class BatchController : Controller
{
    private readonly IBatchService _batchService;

    public BatchController(IBatchService batchService)
    {
        _batchService = batchService;
    }
    
    // GET
    [HttpGet]
    public async Task<IActionResult> GetDeliveryCompanies()
    {
        return await _batchService.GetDeliveryCompanies();
    }
    
    // GET
    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetBatch([FromRoute] Guid id)
    {
        return await _batchService.GetBatch(id);
    }
    
    // POST
    [HttpPost]
    [Authorize]
    public async Task<IActionResult> CreateBatch([FromForm] BatchCreateModel model)
    {
        var user = this.GetAuthenticatedUser();
        return await _batchService.CreateBatch(user.Id, model);
    }
        
    // PUT
    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> UpdateBatch([FromRoute] Guid id, [FromBody] BatchUpdateModel model)
    {
        return await _batchService.UpdateBatch(id, model);
    }
    
    // DELETE
    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> DeleteBatch([FromRoute] Guid id)
    {
        return await _batchService.DeleteBatch(id);
    }
}