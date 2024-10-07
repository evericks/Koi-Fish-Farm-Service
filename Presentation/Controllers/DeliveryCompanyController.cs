using Application.Services.Interfaces;
using Domain.Models.Creates;
using Domain.Models.Update;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[Route("api/delivery-companies")]
[ApiController]
public class DeliveryCompanyController : Controller
{
    private readonly IDeliveryCompanyService _deliveryCompanyService;

    public DeliveryCompanyController(IDeliveryCompanyService deliveryCompanyService)
    {
        _deliveryCompanyService = deliveryCompanyService;
    }
    
    // GET
    [HttpGet]
    public async Task<IActionResult> GetDeliveryCompanies()
    {
        return await _deliveryCompanyService.GetDeliveryCompanies();
    }
    
    // GET
    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetDeliveryCompany([FromRoute] Guid id)
    {
        return await _deliveryCompanyService.GetDeliveryCompany(id);
    }
    
    // POST
    [HttpPost]
    public async Task<IActionResult> CreateDeliveryCompany([FromBody] DeliveryCompanyCreateModel model)
    {
        return await _deliveryCompanyService.CreateDeliveryCompany(model);
    }
        
    // PUT
    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> UpdateDeliveryCompany([FromRoute] Guid id, [FromBody] DeliveryCompanyUpdateModel model)
    {
        return await _deliveryCompanyService.UpdateDeliveryCompany(id, model);
    }
    
    // DELETE
    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> DeleteDeliveryCompany([FromRoute] Guid id)
    {
        return await _deliveryCompanyService.DeleteDeliveryCompany(id);
    }
}