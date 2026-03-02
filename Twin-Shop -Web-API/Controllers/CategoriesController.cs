using Microsoft.AspNetCore.Mvc;
using Twin_Shop__Web_API.Controllers;
using Twin_Shop__Web_API.DTOs.Brand;
using Twin_Shop__Web_API.DTOs.Category;
using Twin_Shop__Web_API.DTOs.Product;
using Twin_Shop__Web_API.Services.Implementations;
using Twin_Shop__Web_API.Services.Interfaces;
using TwinShop.BLL.Profiles;

public class CategoriesController : BaseController
{
    private readonly ICategoryService _categoryService;
    private readonly ILogger<CategoriesController> _logger;

    public CategoriesController(ICategoryService categoryService,ILogger<CategoriesController> logger)
    {
        _categoryService = categoryService;
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var categoriesDto = await _categoryService.GetAllCategoriesAsync();
            if (categoriesDto == null) return NotFound(new { message = "Categories not found" });
            return Ok(categoriesDto);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while getting categories.");
            return StatusCode(StatusCodes.Status500InternalServerError, new { error = "Internal server error" });
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetById(int id)
    {
       
        try
        {
            var categoryDto = await _categoryService.GetCategoryByIdAsync(id);
            if (categoryDto == null) return NotFound(new { message = "Category not found" });
            return Ok(categoryDto)!;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while getting category by id.");
            return StatusCode(StatusCodes.Status500InternalServerError, new { error = "Internal server error" });
        }
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody]CreateCategoryDto dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        try
        {
            var createdCategory = await _categoryService.CreateCategoryAsync(dto);
            return Ok(createdCategory);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while creating category.");

            return StatusCode(StatusCodes.Status500InternalServerError, new { error = "Internal server error" });
        }

    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            var result = await _categoryService.DeleteCategoryAsync(id);
            if (result) return Ok("Category deleted successfully.");
            else return NotFound(new { message = "Category not found" });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while deleting category.");
            return StatusCode(StatusCodes.Status500InternalServerError, new { error = "Internal server error" });
        }
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody]UpdateCategoryDto dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        try
        {
            var result = await _categoryService.UpdateCategoryAsync(dto);
            if (result) return Ok("Category Updated successfully.");
            else return NotFound(new { message = "Category not found." });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while updating category.");

            return StatusCode(StatusCodes.Status500InternalServerError, new { error = "Internal server error" });
        }
    }
 

   
}
