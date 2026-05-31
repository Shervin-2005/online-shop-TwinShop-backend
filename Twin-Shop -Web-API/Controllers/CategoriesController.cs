using Microsoft.AspNetCore.Mvc;
using Twin_Shop__Web_API.Controllers;
using Twin_Shop__Web_API.Services.Interfaces;
using TwinShop.Shared.ViewModels;

public class CategoriesController : BaseController
{
    private readonly ICategoryService _categoryService;

    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _categoryService.GetAllCategoriesAsync();
        return Ok(result);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _categoryService.GetCategoryByIdAsync(id);
        return Ok(result);
    }

    [HttpPost]
    [Consumes("multipart/form-data")]
    public async Task<IActionResult> Create([FromBody]CategoryViewModel categoryViewModel)
    {
        var categoryId = await _categoryService.CreateCategoryAsync(categoryViewModel);

        return CreatedAtAction(nameof(GetById), new { id = categoryId });
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _categoryService.DeleteCategoryAsync(id);
        return NoContent();
    }

    //we must seprate image and brandViewModel because viewModel can't be From form
    [HttpPut("{id:int}")]
    [Consumes("multipart/form-data")]
    public async Task<IActionResult> Update([FromBody]CategoryViewModel categoryViewModel, int id)
    {
        await _categoryService.UpdateCategoryAsync(categoryViewModel, id);
        return NoContent();
    }

    [HttpGet("search")]
    public async Task<IActionResult> SearchCategories([FromQuery] string searchTerm)
    {
        var result= await _categoryService.SearchCategoriesAsync(searchTerm);
        return Ok(result);
    }


}
