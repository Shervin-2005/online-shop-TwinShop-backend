using Microsoft.AspNetCore.Mvc;
using Twin_Shop__Web_API.Controllers;
using Twin_Shop__Web_API.DTOs.Product;
using Twin_Shop__Web_API.Services.Interfaces;

public class ProductsController : BaseController
{
    private readonly IProductService _productService;
    private readonly ILogger<ProductsController> _logger;

    public ProductsController(IProductService productService,ILogger<ProductsController> logger)
    {
        _productService = productService;
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var productsDto = await _productService.GetAllProductsAsync();
            if (productsDto == null) return NotFound(new { message = "Products not found" });
            return Ok(productsDto);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while getting products.");
            return StatusCode(StatusCodes.Status500InternalServerError, new { error = "Internal server error" });
        } 
    }

    [HttpGet]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            var productDto = await _productService.GetProductByIdAsync(id);
            if (productDto == null) return NotFound(new { message = "Product not found" });
            return Ok(productDto)!;
        }
        catch(Exception ex)
        {
            _logger.LogError(ex, "An error occurred while getting product by id.");
            return StatusCode(StatusCodes.Status500InternalServerError, new { error = "Internal server error" });

        }
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody]CreateProductDto dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        try
        {
            var createdProduct = await _productService.CreateProductAsync(dto);
            return Ok(createdProduct);
        }
        catch(Exception ex)
        {
            _logger.LogError(ex, "An error occurred while creating product.");

            return StatusCode(StatusCodes.Status500InternalServerError, new { error = "Internal server error" });
        }
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            var result = await _productService.DeleteProductAsync(id);
            if (result) return Ok("Product deleted successfully.");
            else return NotFound(new { message = "Product not found" });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while deleting product.");
            return StatusCode(StatusCodes.Status500InternalServerError, new { error = "Internal server error" });
        }
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody]UpdateProductDto dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        try
        {
            var result = await _productService.UpdateProductAsync(dto);
            if (result) return Ok("Product Updated successfully.");
            else return NotFound(new { message = "Product not found." });
        }
        catch(Exception ex)
        {
            _logger.LogError(ex, "An error occurred while updating product.");

            return StatusCode(StatusCodes.Status500InternalServerError, new { error = "Internal server error" });
        }
    }
    [HttpGet]
    public async Task<IActionResult> GetProductsByNameAsync(string name)
    {
        try
        {
            var products = await _productService.GetProductsByNameAsync(name);
            if(products == null) return NotFound(new { message = "Products not found" });
            return Ok(products);
        }
        catch(Exception ex)
        {
            _logger.LogError(ex, "An error occurred while getting products by name.");
            return StatusCode(StatusCodes.Status500InternalServerError, new { error = "Internal server error" });
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetProductsByBrandNameAsync(string brandName)
    {
        try
        {
            var products = await _productService.GetProductsByBrandNameAsync(brandName);
            if (products == null) return NotFound(new { message = "Products not found" });
            return Ok(products);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while getting products by brnad name.");
            return StatusCode(StatusCodes.Status500InternalServerError, new { error = "Internal server error" });
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetProductsByCategoryNameAsync(string categoryName)
    {
        try
        {
            var products = await _productService.GetProductsByCategoryNameAsync(categoryName);
            if (products == null) return NotFound(new { message = "Products not found" });
            return Ok(products);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while getting products by category name.");
            return StatusCode(StatusCodes.Status500InternalServerError, new { error = "Internal server error" });
        }
    }
}
