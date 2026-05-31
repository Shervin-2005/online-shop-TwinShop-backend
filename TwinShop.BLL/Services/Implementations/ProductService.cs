using Microsoft.AspNetCore.Http;
using Twin_Shop__Web_API.DTOs.Product;
using Twin_Shop__Web_API.Services.Interfaces;
using TwinShop.BLL.Services.Interfaces;
using TwinShop.BLL.Services.UploadImageService.Interfaces;
using TwinShop.DAL.Repositories.Interfaces;
using TwinShop.Shared.Custom_Exceptions;
using TwinShop.Shared.Mappers;
using TwinShop.Shared.ViewModels;
namespace Twin_Shop__Web_API.Services.Implementations;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IProductValidationService _productValidationService;
    private readonly ISaveProductImagesService _saveProductImagesService;

    public ProductService(IProductRepository productRepository
                         ,IProductValidationService productValidationService
                         ,ISaveProductImagesService saveProductImagesService)
    {
        _productRepository = productRepository;
        _productValidationService = productValidationService;
        _saveProductImagesService = saveProductImagesService;
    }
    public async Task<ProductCardViewModel> GetProductByIdAsync(int id)
    {
        var product = await _productRepository.GetByIdAsync(id);

        if (product == null)
            throw new NotFoundException("Product", id);

        return product.ProductDTOToProductCardViewModel();
    }
    public async Task<int> CreateProductAsync(ProductCardViewModel productViewModel)
    {
        await _productValidationService.ValidateProductAsync(productViewModel);  

        ProductDto productDto = productViewModel.ProductViewModelToProductDTO();
         
        var productId = await _productRepository.InsertAsync(productDto);

        await _saveProductImagesService.UploadProductImages(productViewModel.Images, productId, productViewModel.ProductName!);
        
        return productId;
           
    }
    public async Task<List<ProductCardViewModel>> GetAllProductsAsync()
    {
        var products = await _productRepository.GetAllAsync();
        return products.ProductDTOToProductCardViewModel();
    }
    public async Task DeleteProductAsync(int id)
    {
        if (!await _productRepository.DeleteAsync(id))
            throw new NotFoundException("Product", id);
    }   
    public async Task UpdateProductAsync(ProductCardViewModel productViewModel, int id)
    {
        await _productValidationService.ValidateProductAsync(productViewModel);

        ProductDto productDto = productViewModel.ProductViewModelToProductDTO();

        await _productRepository.UpdateAsync(productDto, id);

        await _saveProductImagesService.UploadProductImages(productViewModel.Images, id, productViewModel.ProductName!);
    }
    public async Task<List<ProductCardViewModel>> GetProductsByCategoryNameAsync(string categoryName)
    {
        var productDTOs = await _productRepository.GetProductsByCategoryNameAsync(categoryName);
        return productDTOs.ProductDTOToProductCardViewModel();   
    }
    public async Task<List<ProductCardViewModel>> SearchProductsAsync(string searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
            return await GetAllProductsAsync();

        var productDTOs = await _productRepository.SearchProductByNameAsync(searchTerm);
        return productDTOs.ProductDTOToProductCardViewModel();   
    }
}
