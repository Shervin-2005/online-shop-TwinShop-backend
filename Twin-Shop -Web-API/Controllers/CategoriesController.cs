using Microsoft.AspNetCore.Mvc;
using Twin_Shop__Web_API.Controllers;
using Twin_Shop__Web_API.DTOs.Category;
using Twin_Shop__Web_API.Services.Interfaces;

public class CategoriesController : BaseController
{
    private readonly ICategoryService _categoryService;

    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    public async Task<IEnumerable<CategoryDto>> GetAll()
    {
        var categoriesDto = await _categoryService.GetAllCategoriesAsync();
        return categoriesDto;
    }

    [HttpGet]
    public async Task<CategoryDto> GetById(int id)
    {
        var categoryDto = await _categoryService.GetCategoryByIdAsync(id);
        return categoryDto!;
    }

    [HttpPost]
    public async Task<CategoryDto> Create(CreateCategoryDto dto)
    {
        var createdCategory = await _categoryService.CreateCategoryAsync(dto);
        return createdCategory;
    }
}
