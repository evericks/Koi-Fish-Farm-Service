using Domain.Models.Creates;
using Microsoft.AspNetCore.Mvc;

namespace Application.Services.Interfaces;

public interface IDeliveryCompanyService
{
    Task<IActionResult> GetDeliveryCompanies();
    Task<IActionResult> GetDeliveryCompany(Guid id);
    Task<IActionResult> CreateDeliveryCompany(DeliveryCompanyCreateModel model);
    Task<IActionResult> DeleteDeliveryCompany(Guid id);
}