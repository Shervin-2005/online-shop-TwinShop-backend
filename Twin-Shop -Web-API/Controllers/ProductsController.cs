using Microsoft.AspNetCore.Mvc;
using Twin_Shop__Web_API.Controllers;
using Twin_Shop__Web_API.DTOs.Product;
using Twin_Shop__Web_API.Entities;
using Twin_Shop__Web_API.Services.Implementations;
using Twin_Shop__Web_API.Services.Interfaces;
using TwinShop.Shared;
using TwinShop.Shared.ViewModels;

public class ProductsController : BaseController
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<OperationResult> GetAll()
    {
        var result = await _productService.GetAllProductsAsync();
        return result;
    }

    [HttpGet]
    public async Task<OperationResult> GetById(int id)
    {
            var result = await _productService.GetProductByIdAsync(id);
            return result;
    } 

    [HttpPost]
    public async Task<OperationResult> Create([FromBody] ProductCardViewModel productCardViewModel)
    {
        var result = await _productService.CreateProductAsync(productCardViewModel);
        return result;
    }

    [HttpDelete]
    public async Task<OperationResult> Delete(int id)
    {
        var result = await _productService.DeleteProductAsync(id);
        return result;
    }

    [HttpPost]
    public async Task<OperationResult> Update([FromBody]ProductCardViewModel productView,int id)
    {

        var result = await _productService.UpdateProductAsync(productView,id);
        return result;
    }
    [HttpGet]
    public async Task<OperationResult<List<ProductDto>>> GetProductsByNameAsync(string name)
    {
        var result = await _productService.GetProductsByNameAsync(name);
        return result;
    }

    [HttpGet]
    public async Task<OperationResult<List<ProductDto>>> GetProductsByBrandNameAsync(string brandName)
    {
        var result = await _productService.GetProductsByBrandNameAsync(brandName);
        return result;
    }
     
    [HttpGet]
    public async Task<OperationResult<List<ProductDto>>> GetProductsByCategoryNameAsync(string categoryName)
    {
        var result = await _productService.GetProductsByCategoryNameAsync(categoryName);
        return result;
    }
    [HttpGet]
    public async Task<OperationResult> SearchProducts(string searchTerm)
    {
        var result = await _productService.SearchProductsAsync(searchTerm);
        return result;
    }
}
