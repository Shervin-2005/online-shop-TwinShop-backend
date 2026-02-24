using Microsoft.AspNetCore.Mvc;
using Twin_Shop__Web_API.Controllers;
using Twin_Shop__Web_API.DTOs.Product;
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
}
