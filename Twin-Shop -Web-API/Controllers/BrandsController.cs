using Microsoft.AspNetCore.Mvc;
using Twin_Shop__Web_API.Controllers;
using Twin_Shop__Web_API.DTOs.Brand;
using Twin_Shop__Web_API.Services.Interfaces;

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
        var brandsDto = await _brandService.GetAllBrandsAsync();
        return Ok(brandsDto);
    }

    [HttpGet]
    public async Task<BrandDto> GetById(int id)
    {
        var brandDto = await _brandService.GetBrandByIdAsync(id);
        if (brandDto == null)
            return null;

        return brandDto!;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateBrandDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var createdBrand = await _brandService.CreateBrandAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = createdBrand.BrandId }, createdBrand);
    }
}
