using Application.Services.Interfaces;
using Domain.Models.Creates;
using Domain.Models.Update;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[Route("api/categories")]
[ApiController]
public class CategoryController : Controller
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }
    
    // GET
    [HttpGet]
    public async Task<IActionResult> GetCategories()
    {
        return await _categoryService.GetCategories();
    }
    
    // GET
    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetCategory([FromRoute] Guid id)
    {
        return await _categoryService.GetCategory(id);
    }
    
    // POST
    [HttpPost]
    public async Task<IActionResult> CreateCategory([FromBody] CategoryCreateModel model)
    {
        return await _categoryService.CreateCategory(model);
    }
        
    // PUT
    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> UpdateCategory([FromRoute] Guid id, [FromBody] CategoryUpdateModel model)
    {
        return await _categoryService.UpdateCategory(id, model);
    }
    
    // DELETE
    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> DeleteCategory([FromRoute] Guid id)
    {
        return await _categoryService.DeleteCategory(id);
    }
}