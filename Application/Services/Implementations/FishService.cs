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

public class FishService : BaseService, IFishService
{
    private readonly IFishRepository _fishRepository;
    private readonly IFishCategoryRepository _fishCategoryRepository;

    public FishService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
        _fishRepository = unitOfWork.Fish;
        _fishCategoryRepository = unitOfWork.FishCategory;
    }

    public async Task<IActionResult> GetFish()
    {
        var deliveryCompanies = await _unitOfWork.Fish.GetAll()
            .OrderByDescending(x => x.CreateAt)
            .ProjectTo<FishViewModel>(_mapper.ConfigurationProvider).ToListAsync();
        return new OkObjectResult(deliveryCompanies);
    }

    public async Task<IActionResult> GetFish(Guid id)
    {
        var fish = await _unitOfWork.Fish.Where(x => x.Id.Equals(id))
            .ProjectTo<FishViewModel>(_mapper.ConfigurationProvider).FirstOrDefaultAsync();
        return new OkObjectResult(fish);
    }

    public async Task<IActionResult> CreateFish(Guid creatorId, FishCreateModel model)
    {
        var fish = _mapper.Map<Fish>(model);
        fish.CreatorId = creatorId;
        fish.ThumbnailUrl = "";
        _fishRepository.Add(fish);
        
        var result = await _unitOfWork.SaveChangesAsync();

        foreach (var item in model.FishCategories)
        {
            var fishCategory = new FishCategory
            {
                Id = Guid.NewGuid(),
                FishId = fish.Id,
                CategoryId = item.CategoryId
            };
            _fishCategoryRepository.Add(fishCategory);
        }

        await _unitOfWork.SaveChangesAsync();
        return result > 0 ? await GetFish(fish.Id) : new BadRequestResult();
    }

    public async Task<IActionResult> UpdateFish(Guid id, FishUpdateModel model)
    {
        var fish = _mapper.Map<Fish>(model);
        _fishRepository.Update(fish);
        var result = await _unitOfWork.SaveChangesAsync();
        return result > 0 ? await GetFish(fish.Id) : new BadRequestResult();
    }

    public async Task<IActionResult> DeleteFish(Guid id)
    {
        var fish = await _fishRepository
            .Where(b => b.Id.Equals(id))
            .FirstOrDefaultAsync();
        if (fish == null)
        {
            return new BadRequestResult();
        }

        _fishRepository.Delete(fish);
        var result = await _unitOfWork.SaveChangesAsync();
        return result > 0 ? new NoContentResult() : new BadRequestResult();
    }
}