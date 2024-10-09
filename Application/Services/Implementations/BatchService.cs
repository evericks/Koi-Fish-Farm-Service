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

public class BatchService : BaseService, IBatchService
{
    private readonly IBatchRepository _batchRepository;

    public BatchService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
        _batchRepository = unitOfWork.Batch;
    }

    public async Task<IActionResult> GetDeliveryCompanies()
    {
        var deliveryCompanies = await _unitOfWork.Batch.GetAll()
            .OrderByDescending(x => x.CreateAt)
            .ProjectTo<BatchViewModel>(_mapper.ConfigurationProvider).ToListAsync();
        return new OkObjectResult(deliveryCompanies);
    }

    public async Task<IActionResult> GetBatch(Guid id)
    {
        var batch = await _unitOfWork.Batch.Where(x => x.Id.Equals(id))
            .ProjectTo<BatchViewModel>(_mapper.ConfigurationProvider).FirstOrDefaultAsync();
        return new OkObjectResult(batch);
    }

    public async Task<IActionResult> CreateBatch(Guid creatorId, BatchCreateModel model)
    {
        var batch = _mapper.Map<Batch>(model);
        batch.ThumbnailUrl = "";
        batch.CreatorId = creatorId;
        foreach (var fish in batch.Fish)
        {
            fish.CreatorId = creatorId;
            fish.ThumbnailUrl = "";
        }
        _batchRepository.Add(batch);
        var result = await _unitOfWork.SaveChangesAsync();
        return result > 0 ? await GetBatch(batch.Id) : new BadRequestResult();
    }

    public async Task<IActionResult> UpdateBatch(Guid id, BatchUpdateModel model)
    {
        var batch = _mapper.Map<Batch>(model);
        _batchRepository.Update(batch);
        var result = await _unitOfWork.SaveChangesAsync();
        return result > 0 ? await GetBatch(batch.Id) : new BadRequestResult();
    }

    public async Task<IActionResult> DeleteBatch(Guid id)
    {
        var batch = await _batchRepository
            .Where(b => b.Id.Equals(id))
            .FirstOrDefaultAsync();
        if (batch == null)
        {
            return new BadRequestResult();
        }
        _batchRepository.Delete(batch);
        var result = await _unitOfWork.SaveChangesAsync();
        return result > 0 ? new NoContentResult() : new BadRequestResult();
    }
}