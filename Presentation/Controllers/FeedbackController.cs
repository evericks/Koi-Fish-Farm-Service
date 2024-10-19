using Application.Services.Interfaces;
using Domain.Models.Creates;
using Domain.Models.Update;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[Route("api/feedbacks")]
[ApiController]
public class FeedbackController : Controller
{
    private readonly IFeedbackService _feedbackService;

    public FeedbackController(IFeedbackService feedbackService)
    {
        _feedbackService = feedbackService;
    }
    
    // GET
    [HttpGet]
    public async Task<IActionResult> GetFeedbacks()
    {
        return await _feedbackService.GetFeedbacks();
    }
    
    // GET
    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetFeedback([FromRoute] Guid id)
    {
        return await _feedbackService.GetFeedback(id);
    }
    
    // POST
    [HttpPost]
    // [Authorize(UserFeedbacks.Admin)]
    public async Task<IActionResult> CreateFeedback([FromBody] FeedbackCreateModel model)
    {
        return await _feedbackService.CreateFeedback(model);
    }
        
    // PUT
    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> UpdateFeedback([FromRoute] Guid id, [FromBody] FeedbackUpdateModel model)
    {
        return await _feedbackService.UpdateFeedback(id, model);
    }
    
    // DELETE
    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> DeleteFeedback([FromRoute] Guid id)
    {
        return await _feedbackService.DeleteFeedback(id);
    }
}