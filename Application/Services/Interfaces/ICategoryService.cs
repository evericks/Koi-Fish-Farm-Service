using Domain.Models.Creates;
using Domain.Models.Update;
using Microsoft.AspNetCore.Mvc;

namespace Application.Services.Interfaces;

public interface ICategoryService
{
    Task<IActionResult> GetCategories();
    Task<IActionResult> GetCategory(Guid id);
    Task<IActionResult> CreateCategory(CategoryCreateModel model);
    Task<IActionResult> UpdateCategory(Guid id, CategoryUpdateModel model);
    Task<IActionResult> DeleteCategory(Guid id);
    
}