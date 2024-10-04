using Application.Services.Interfaces;
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
}