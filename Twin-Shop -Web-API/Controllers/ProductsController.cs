using Microsoft.AspNetCore.Mvc;
using Twin_Shop__Web_API.Controllers;
using Twin_Shop__Web_API.Services.Interfaces;
using TwinShop.Shared.ViewModels;

public class ProductsController : BaseController
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _productService.GetAllProductsAsync();
        return Ok(result);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _productService.GetProductByIdAsync(id);
        return Ok(result);
    } 

    [HttpPost]
    [Consumes("multipart/form-data")]
    public async Task<IActionResult> Create([FromForm] ProductCardViewModel productCardViewModel)
    {
        var productId = await _productService.CreateProductAsync(productCardViewModel);

        return CreatedAtAction(nameof(GetById), new {id = productId});
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _productService.DeleteProductAsync(id);
        return NoContent();
    }

    [HttpPut("{id:int}")]
    [Consumes("multipart/form-data")]
    public async Task<IActionResult> Update([FromForm]ProductCardViewModel productViewModel, int id)
    {
        await _productService.UpdateProductAsync(productViewModel, id);
        return NoContent();
    } 

    [HttpGet("by-category/{categoryName}")]
    public async Task<IActionResult> GetProductsByCategoryNameAsync(string categoryName)
    {
        var result = await _productService.GetProductsByCategoryNameAsync(categoryName);
        return Ok(result);
    }

    [HttpGet("search")]
    public async Task<IActionResult> SearchProducts([FromQuery] string searchTerm)
    {
        var result = await _productService.SearchProductsAsync(searchTerm);
        return Ok(result);
    }
}
