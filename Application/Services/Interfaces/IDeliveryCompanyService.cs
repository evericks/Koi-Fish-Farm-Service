using Microsoft.AspNetCore.Mvc;

namespace Application.Services.Interfaces;

public interface IDeliveryCompanyService
{
    Task<IActionResult> GetDeliveryCompanies();
}