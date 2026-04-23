
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Twin_Shop__Web_API.Controllers;
using Twin_Shop__Web_API.DTOs.Brand;
using Twin_Shop__Web_API.Services.Implementations;
using Twin_Shop__Web_API.Services.Interfaces;
using TwinShop.Shared;
using TwinShop.Shared.ViewModels;

public class BrandsController : BaseController
{
    private readonly IBrandService _brandService;
    public BrandsController(IBrandService brandService)
    {
        _brandService = brandService;
    }

    [HttpGet]
    public async Task<OperationResult> GetAll()
    {
       var result=await _brandService.GetAllBrandsAsync();
        return result;
    }

    [HttpGet]
    public async Task<OperationResult> GetById(int id)
    {
        var result = await _brandService.GetBrandByIdAsync(id);
        return result;
    }

    [HttpPost]
    public async Task<OperationResult> Create([FromBody]BrandViewModel brandViewModel)
    {
        var result = await _brandService.CreateBrandAsync(brandViewModel);
        return result;
    }

    [HttpDelete]
    public async Task<OperationResult> Delete(int id)
    {
        var result = await _brandService.DeleteBrandAsync(id);
        return result;
    }

    [HttpPost]
    public async Task<OperationResult> Update([FromBody]BrandViewModel brandView,int id)
    {
        var result = await _brandService.UpdateBrandAsync(brandView,id);
        return result;
    }

    [HttpGet]
    public async Task<OperationResult> GetBrandsByName(string name)
    {
        var result = await _brandService.GetBrandsByNameAsync(name);
        return result;
    }

    [HttpGet]
    public async Task<OperationResult> GetBrandsByCategoryName(string categoryName)
    {
        var result = await _brandService.GetBrandsByCategoryNameAsync(categoryName);
        return result;
    }

    [HttpGet]
    public async Task<OperationResult> SearchBrands(string searchTerm)
    {
        var result= await _brandService.SearchBrandsAsync(searchTerm);
        return result;  
    }
}
