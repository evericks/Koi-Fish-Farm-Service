using Domain.Models.Creates;
using Domain.Models.Update;
using Microsoft.AspNetCore.Mvc;

namespace Application.Services.Interfaces;

public interface IDeliveryCompanyService
{
    Task<IActionResult> GetDeliveryCompanies();
    Task<IActionResult> GetDeliveryCompany(Guid id);
    Task<IActionResult> CreateDeliveryCompany(DeliveryCompanyCreateModel model);
    Task<IActionResult> UpdateDeliveryCompany(Guid id, DeliveryCompanyUpdateModel model);
    Task<IActionResult> DeleteDeliveryCompany(Guid id);
}