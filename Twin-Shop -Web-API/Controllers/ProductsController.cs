using Microsoft.AspNetCore.Mvc;
using Twin_Shop__Web_API.Controllers;
using Twin_Shop__Web_API.DTOs.Brand;
using Twin_Shop__Web_API.DTOs.Product;
using Twin_Shop__Web_API.Services.Implementations;
using Twin_Shop__Web_API.Services.Interfaces;

public class ProductsController : BaseController
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<IEnumerable<ProductDto>> GetAll()
    {
        var productsDto = await _productService.GetAllProductsAsync();
        return productsDto;
    }

    [HttpGet]
    public async Task<ProductDto> GetById(int id)
    {
        var productDto = await _productService.GetProductByIdAsync(id);
        return productDto!;
    }

    [HttpPost]
    public async Task<ProductDto> Create(CreateProductDto dto)
    {
        var createdProduct = await _productService.CreateProductAsync(dto);
        return createdProduct;
    }

    [HttpDelete]
    public async Task<bool> Delete(int id)
    {
        var result = await _productService.DeleteProductAsync(id);
        return result;
    }

    [HttpPut]
    public async Task<bool> Update(UpdateProductDto dto)
    {
        var result = await _productService.UpdateProductAsync(dto);
        return result;
    }
    [HttpGet]
    public async Task<List<ProductDto>> GetProductsByNameAsync(string name)
    {
        var products = await _productService.GetProductsByNameAsync(name);
        return products!;
    }

    [HttpGet]
    public async Task<List<ProductDto>> GetProductsByBrandNameAsync(string brandName)
    {
        var products = await _productService.GetProductsByNameAsync(brandName);
        return products!;
    }

    [HttpGet]
    public async Task<List<ProductDto>> GetProductsByCategoryNameAsync(string categoryName)
    {
        var products = await _productService.GetProductsByCategoryNameAsync(categoryName);
        return products!;
    }
}
