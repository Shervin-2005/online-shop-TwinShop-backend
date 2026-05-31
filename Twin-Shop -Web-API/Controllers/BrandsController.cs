using Microsoft.AspNetCore.Mvc;
using Twin_Shop__Web_API.Controllers;
using Twin_Shop__Web_API.Services.Interfaces;
using TwinShop.Shared.ViewModels;

public class BrandsController : BaseController
{
    private readonly IBrandService _brandService;

    public BrandsController(IBrandService brandService)
    {
        _brandService = brandService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _brandService.GetAllBrandsAsync();
        return Ok(result);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _brandService.GetBrandByIdAsync(id);
        return Ok(result);
    }

    [HttpPost]
    [Consumes("multipart/form-data")]
    public async Task<IActionResult> Create([FromForm] BrandViewModel brandViewModel)
    {
        var brandId = await _brandService.CreateBrandAsync(brandViewModel);

        return CreatedAtAction(nameof(GetById), new { id = brandId });
    }

    [HttpPut("{id:int}")]
    [Consumes("multipart/form-data")]
    public async Task<IActionResult> Update([FromForm] BrandViewModel brandViewModel, int id)
    {
        await _brandService.UpdateBrandAsync(brandViewModel, id);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _brandService.DeleteBrandAsync(id);
        return NoContent();
    }

    [HttpGet("by-category/{categoryName}")]
    public async Task<IActionResult> GetBrandsByCategoryName(string categoryName)
    {
        var result = await _brandService.GetBrandsByCategoryNameAsync(categoryName);
        return Ok(result);
    }

    [HttpGet("search")]
    public async Task<IActionResult> SearchBrands([FromQuery] string searchTerm)
    {
        var result = await _brandService.SearchBrandsAsync(searchTerm);
        return Ok(result);
    }
}
