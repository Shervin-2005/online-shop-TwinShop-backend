using AutoMapper;
using Microsoft.Extensions.Logging;
using Twin_Shop__Web_API.DTOs.Product;
using Twin_Shop__Web_API.Entities;
using Twin_Shop__Web_API.Services.Interfaces;
using TwinShop.DAL.Repositories.Interfaces;
namespace Twin_Shop__Web_API.Services.Implementations;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<ProductService> _logger;

    public ProductService(IProductRepository productRepository, IMapper mapper,ILogger<ProductService> logger)
    {
        _productRepository =  productRepository;
        _mapper = mapper;
        _logger = logger;
    }
    public async Task<ProductDto?> GetProductByIdAsync(int id)
    {
        try
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product != null) return _mapper.Map<ProductDto>(product);
            else
            {
                _logger.LogError("No Product found with ProductId: {ProductId}", id);
                throw new Exception("No product found with the provided ProductId");
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while getting product by ID: {Id}", id);
            throw;
        }
    }

    public async Task<ProductDto> CreateProductAsync(CreateProductDto dto)
    {
        try
        {
            var product = _mapper.Map<Product>(dto);
            await _productRepository.InsertAsync(product);
            return _mapper.Map<ProductDto>(product);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while creating a new product.");
            throw;
        }
    }

    public async Task<List<ProductDto>> GetAllProductsAsync()
    {
        try
        {
            var products = await _productRepository.GetAllAsync();
            return _mapper.Map<List<ProductDto>>(products);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while getting all products.");
            throw;
        }
    }

    public async Task<bool> DeleteProductAsync(int id)
    {
        try
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product != null) return await _productRepository.DeleteAsync(id);
            else return false;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while deleting product by ID: {Id}", id);
            throw;
        }
    }

    public async Task<bool> UpdateProductAsync(UpdateProductDto dto)
    {
        try
        {
            var product = _mapper.Map<Product>(dto);
            return await _productRepository.UpdateAsync(product);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while updating product.");
            throw;
        }
    }
    public async Task<List<ProductDto>> GetProductsByNameAsync(string name)
    {
        try
        {
            var products = await _productRepository.GetProductsByNameAsync(name);
            return _mapper.Map<List<ProductDto>>(products)!;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while getting products by name: {Name}", name);
            throw;
        }
    }

    public async Task<List<ProductDto>> GetProductsByBrandNameAsync(string brandName)
    {
        try
        {
            var products = await _productRepository.GetProductsByBrandNameAsync(brandName);
            return _mapper.Map<List<ProductDto>>(products)!;
        }
        catch (Exception ex)
        {
            // Log the exception using ILogger
            _logger.LogError(ex, "Error occurred while getting products by brand name: {BrandName}", brandName);
            throw;
        }

    }

    public async Task<List<ProductDto>> GetProductsByCategoryNameAsync(string categoryName)
    {
        try
        {
            var products = await _productRepository.GetProductsByCategoryNameAsync(categoryName);
            return _mapper.Map<List<ProductDto>>(products)!;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while getting products by category name: {CategoryName}", categoryName);
            throw;
        }
    }
}
