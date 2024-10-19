using Application.Services.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Data.EntityRepositories.Interfaces;
using Data.UnitOfWorks.Interfaces;
using Domain.Entities;
using Domain.Models.Creates;
using Domain.Models.Update;
using Domain.Models.Views;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.Implementations;

public class FeedbackService : BaseService, IFeedbackService
{
    private readonly IFeedbackRepository _feedbackRepository;

    public FeedbackService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
        _feedbackRepository = unitOfWork.Feedback;
    }

    public async Task<IActionResult> GetFeedbacks()
    {
        var deliveryCompanies = await _unitOfWork.Feedback.GetAll()
            .OrderByDescending(x => x.CreateAt)
            .ProjectTo<FeedbackViewModel>(_mapper.ConfigurationProvider).ToListAsync();
        return new OkObjectResult(deliveryCompanies);
    }

    public async Task<IActionResult> GetFeedback(Guid id)
    {
        var feedback = await _unitOfWork.Feedback.Where(x => x.Id.Equals(id))
            .ProjectTo<FeedbackViewModel>(_mapper.ConfigurationProvider).FirstOrDefaultAsync();
        return new OkObjectResult(feedback);
    }

    public async Task<IActionResult> CreateFeedback(FeedbackCreateModel model)
    {
        var feedback = _mapper.Map<Feedback>(model);
        _feedbackRepository.Add(feedback);
        var result = await _unitOfWork.SaveChangesAsync();
        return result > 0 ? await GetFeedback(feedback.Id) : new BadRequestResult();
    }

    public async Task<IActionResult> UpdateFeedback(Guid id, FeedbackUpdateModel model)
    {
        var feedback = _mapper.Map<Feedback>(model);
        _feedbackRepository.Update(feedback);
        var result = await _unitOfWork.SaveChangesAsync();
        return result > 0 ? await GetFeedback(feedback.Id) : new BadRequestResult();
    }

    public async Task<IActionResult> DeleteFeedback(Guid id)
    {
        var feedback = await _feedbackRepository
            .Where(b => b.Id.Equals(id))
            .FirstOrDefaultAsync();
        if (feedback == null)
        {
            return new BadRequestResult();
        }
        _feedbackRepository.Delete(feedback);
        var result = await _unitOfWork.SaveChangesAsync();
        return result > 0 ? new NoContentResult() : new BadRequestResult();
    }
}