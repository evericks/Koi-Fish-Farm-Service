using Domain.Models.Creates;
using Domain.Models.Update;
using Microsoft.AspNetCore.Mvc;

namespace Application.Services.Interfaces;

public interface IBatchService
{
    Task<IActionResult> GetDeliveryCompanies();
    Task<IActionResult> GetBatch(Guid id);
    Task<IActionResult> CreateBatch(Guid creatorId, BatchCreateModel model);
    Task<IActionResult> UpdateBatch(Guid id, BatchUpdateModel model);
    Task<IActionResult> DeleteBatch(Guid id);
}