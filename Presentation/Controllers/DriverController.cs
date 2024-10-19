using Application.Services.Interfaces;
using Domain.Models.Creates;
using Domain.Models.Update;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[Route("api/drivers")]
[ApiController]
public class DriverController : Controller
{
    private readonly IDriverService _driverService;

    public DriverController(IDriverService driverService)
    {
        _driverService = driverService;
    }
    
    // GET
    [HttpGet]
    public async Task<IActionResult> GetDrivers()
    {
        return await _driverService.GetDrivers();
    }
    
    // GET
    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetDriver([FromRoute] Guid id)
    {
        return await _driverService.GetDriver(id);
    }
    
    // POST
    [HttpPost]
    // [Authorize(UserDrivers.Admin)]
    public async Task<IActionResult> CreateDriver([FromBody] DriverCreateModel model)
    {
        return await _driverService.CreateDriver(model);
    }
        
    // PUT
    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> UpdateDriver([FromRoute] Guid id, [FromBody] DriverUpdateModel model)
    {
        return await _driverService.UpdateDriver(id, model);
    }
    
    // DELETE
    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> DeleteDriver([FromRoute] Guid id)
    {
        return await _driverService.DeleteDriver(id);
    }
}