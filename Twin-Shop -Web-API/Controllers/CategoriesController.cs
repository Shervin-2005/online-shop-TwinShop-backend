using Microsoft.AspNetCore.Mvc;
using Twin_Shop__Web_API.Controllers;
using Twin_Shop__Web_API.DTOs.Brand;
using Twin_Shop__Web_API.DTOs.Category;
using Twin_Shop__Web_API.DTOs.Product;
using Twin_Shop__Web_API.Services.Implementations;
using Twin_Shop__Web_API.Services.Interfaces;
using TwinShop.Shared;
using TwinShop.Shared.ViewModels;

public class CategoriesController : BaseController
{
    private readonly ICategoryService _categoryService;

    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    public async Task<OperationResult> GetAll()
    {
        var result = await _categoryService.GetAllCategoriesAsync();
        return result;
    }

    [HttpGet]
    public async Task<OperationResult> GetById(int id)
    {
        var result = await _categoryService.GetCategoryByIdAsync(id);
        return result;
    }

    [HttpPost]
    public async Task<OperationResult> Create([FromBody]CategoryViewModel categoryView)
    {
        var result = await _categoryService.CreateCategoryAsync(categoryView);
        return result;
    }

    [HttpDelete]
    public async Task<OperationResult> Delete(int id)
    {
        var result = await _categoryService.DeleteCategoryAsync(id);
        return result;
    }

    [HttpPost]
    public async Task<OperationResult> Update([FromBody]CategoryViewModel categoryView,int id)
    {
        var result = await _categoryService.UpdateCategoryAsync(categoryView, id);
        return result;
    }
    [HttpGet]
   public async Task<OperationResult> GetCategoriesByName(string name)
    {
        var result=await _categoryService.GetCategoriesByNameAsync(name);
        return result;
    }

    [HttpGet]
    public async Task<OperationResult> GetCategoryByName(string name)
    {
        var result = await _categoryService.GetCategoryByNameAsync(name);
        return result;
    }
   [HttpGet]
   public async Task<OperationResult> SearchCategories(string searchTerm)
    {
        var result= await _categoryService.SearchCategoriesAsync(searchTerm);
        return result;
    }


}
