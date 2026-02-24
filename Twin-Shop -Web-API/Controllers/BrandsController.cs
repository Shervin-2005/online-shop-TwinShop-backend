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
    public async Task<IEnumerable<BrandDto>> GetAll()
    {
        var brandsDto = await _brandService.GetAllBrandsAsync();
        return brandsDto;
    }

    [HttpGet]
    public async Task<BrandDto> GetById(int id)
    {
        var brandDto = await _brandService.GetBrandByIdAsync(id);
        return brandDto!;
    }

    [HttpPost]
    public async Task<BrandDto> Create(CreateBrandDto dto)
    {
        var createdBrand = await _brandService.CreateBrandAsync(dto);
        return createdBrand;
    }
}
