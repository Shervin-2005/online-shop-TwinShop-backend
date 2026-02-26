using System.Threading.Tasks.Sources;
using AutoMapper;
using Twin_Shop__Web_API.DTOs.Category;
using Twin_Shop__Web_API.DTOs.Product;
using Twin_Shop__Web_API.Entities;
using Twin_Shop__Web_API.Services.Interfaces;
using TwinShop.DAL.Repositories.Implementations;
using TwinShop.DAL.Repositories.Interfaces;
namespace Twin_Shop__Web_API.Services.Implementations;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;


    public ProductService(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository =  productRepository;
        _mapper = mapper;
    }
    public async Task<ProductDto?> GetProductByIdAsync(int id)
    {
        var product = await _productRepository.GetByIdAsync(id);
        if (product == null) return null;

        return _mapper.Map<ProductDto>(product);
    }

    public async Task<ProductDto> CreateProductAsync(CreateProductDto dto)
    {
        var product = _mapper.Map<Product>(dto);
        await _productRepository.InsertAsync(product);
        return _mapper.Map<ProductDto>(product);
    }

    public async Task<List<ProductDto>> GetAllProductsAsync()
    {
        var products = await _productRepository.GetAllAsync();
        return _mapper.Map<List<ProductDto>>(products);
    }

    public async Task<bool> DeleteProductAsync(int id)
    {
        var product = await _productRepository.GetByIdAsync(id);
        if (product == null)
            return false;

        return await _productRepository.DeleteAsync(id);
    }

    public async Task<bool> UpdateProductAsync(UpdateProductDto dto)
    {

        var product = _mapper.Map<Product>(dto);
        return await _productRepository.UpdateAsync(product);
    }
    public async Task<List<ProductDto>> GetProductsByNameAsync(string name)
    {
        var products = await _productRepository.GetProductsByNameAsync(name);
        return _mapper.Map<List<ProductDto>>(products)!;
    }

    public async Task<List<ProductDto>> GetProductsByBrandNameAsync(string brandName)
    {
        var products =await _productRepository.GetProductsByBrandNameAsync(brandName);
        return _mapper.Map<List<ProductDto>>(products)!;
    }

    public async Task<List<ProductDto>> GetProductsByCategoryNameAsync(string categoryName)
    {
        var products = await _productRepository.GetProductsByCategoryNameAsync(categoryName);
        return _mapper.Map<List<ProductDto>>(products)!;
    }
}
