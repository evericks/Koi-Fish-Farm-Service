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

public class CategoryService : BaseService, ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
        _categoryRepository = unitOfWork.Category;
    }

    public async Task<IActionResult> GetCategories()
    {
        var deliveryCompanies = await _unitOfWork.Category.GetAll()
            .OrderByDescending(x => x.CreateAt)
            .ProjectTo<CategoryViewModel>(_mapper.ConfigurationProvider).ToListAsync();
        return new OkObjectResult(deliveryCompanies);
    }

    public async Task<IActionResult> GetCategory(Guid id)
    {
        var category = await _unitOfWork.Category.Where(x => x.Id.Equals(id))
            .ProjectTo<CategoryViewModel>(_mapper.ConfigurationProvider).FirstOrDefaultAsync();
        return new OkObjectResult(category);
    }

    public async Task<IActionResult> CreateCategory(CategoryCreateModel model)
    {
        var category = _mapper.Map<Category>(model);
        _categoryRepository.Add(category);
        var result = await _unitOfWork.SaveChangesAsync();
        return result > 0 ? await GetCategory(category.Id) : new BadRequestResult();
    }

    public async Task<IActionResult> UpdateCategory(Guid id, CategoryUpdateModel model)
    {
        var category = _mapper.Map<Category>(model);
        _categoryRepository.Update(category);
        var result = await _unitOfWork.SaveChangesAsync();
        return result > 0 ? await GetCategory(category.Id) : new BadRequestResult();
    }

    public async Task<IActionResult> DeleteCategory(Guid id)
    {
        var category = await _categoryRepository
            .Where(b => b.Id.Equals(id))
            .FirstOrDefaultAsync();
        if (category == null)
        {
            return new BadRequestResult();
        }
        _categoryRepository.Delete(category);
        var result = await _unitOfWork.SaveChangesAsync();
        return result > 0 ? new NoContentResult() : new BadRequestResult();
    }
}