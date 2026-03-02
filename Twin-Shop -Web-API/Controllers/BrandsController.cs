
using Microsoft.AspNetCore.Mvc;
using Twin_Shop__Web_API.Controllers;
using Twin_Shop__Web_API.DTOs.Brand;
using Twin_Shop__Web_API.Services.Implementations;
using Twin_Shop__Web_API.Services.Interfaces;

public class BrandsController : BaseController
{
    private readonly IBrandService _brandService;
    private readonly ILogger<BrandsController> _logger;
    public BrandsController(IBrandService brandService,ILogger<BrandsController> logger)
    {
        _brandService = brandService;
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var brandsDto = await _brandService.GetAllBrandsAsync();
            if (brandsDto == null) return NotFound(new { message = "Brands not found" });
            return Ok(brandsDto);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while getting brands.");
            return StatusCode(StatusCodes.Status500InternalServerError, new { error = "Internal server error" });
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            var brandDto = await _brandService.GetBrandByIdAsync(id);
            if (brandDto == null) return NotFound(new { message = "Brand not found" });
            return Ok(brandDto)!;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while getting brand by id.");
            return StatusCode(StatusCodes.Status500InternalServerError, new { error = "Internal server error" });
        }
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody]CreateBrandDto dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        try
        {
            var createdBrand = await _brandService.CreateBrandAsync(dto);
            return Ok(createdBrand);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while creating brand.");

            return StatusCode(StatusCodes.Status500InternalServerError, new { error = "Internal server error" });
        }
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            var result = await _brandService.DeleteBrandAsync(id);
            if (result) return Ok("Brand deleted successfully.");
            else return NotFound(new { message = "Brand not found" });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while deleting brand.");
            return StatusCode(StatusCodes.Status500InternalServerError, new { error = "Internal server error" });
        }
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody]UpdateBrandDto dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        try
        {
            var result = await _brandService.UpdateBrandAsync(dto);            
            if (result) return Ok("Brand Updated successfully.");
            else return NotFound(new { message = "Brand not found." });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while updating brand.");

            return StatusCode(StatusCodes.Status500InternalServerError, new { error = "Internal server error" });
        }
    }

    [HttpGet]
    public async Task<IActionResult>GetBrandsByName(string name)
    {
        try
        {
            var brands = await _brandService.GetBrandByNameAsync(name);
            if (brands == null) return NotFound(new { message = "Brands not found" });
            return Ok(brands);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while getting brands by name.");
            return StatusCode(StatusCodes.Status500InternalServerError, new { error = "Internal server error" });
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetBrandsByCategoryName(string categoryName)
    {
        try
        {
            var brands = await _brandService.GetBrandsByCategoryNameAsync(categoryName);
            if (brands == null) return NotFound(new { message = "Brands not found" });
            return Ok(brands);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while getting brands by category name.");
            return StatusCode(StatusCodes.Status500InternalServerError, new { error = "Internal server error" });
        }
    }
}
