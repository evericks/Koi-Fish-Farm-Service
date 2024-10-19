using Domain.Models.Creates;
using Domain.Models.Update;
using Microsoft.AspNetCore.Mvc;

namespace Application.Services.Interfaces;

public interface IFeedbackService
{
    Task<IActionResult> GetFeedbacks();
    Task<IActionResult> GetFeedback(Guid id);
    Task<IActionResult> CreateFeedback(FeedbackCreateModel model);
    Task<IActionResult> UpdateFeedback(Guid id, FeedbackUpdateModel model);
    Task<IActionResult> DeleteFeedback(Guid id);
    
}