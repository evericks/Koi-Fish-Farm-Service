using Domain.Models.Creates;
using Domain.Models.Update;
using Microsoft.AspNetCore.Mvc;

namespace Application.Services.Interfaces;

public interface IFishService
{
    Task<IActionResult> GetFish();
    Task<IActionResult> GetFish(Guid id);
    Task<IActionResult> CreateFish(Guid createorId, FishCreateModel model);
    Task<IActionResult> UpdateFish(Guid id, FishUpdateModel model);
    Task<IActionResult> DeleteFish(Guid id);
}