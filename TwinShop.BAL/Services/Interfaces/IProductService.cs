using Twin_Shop__Web_API.DTOs.Category;
using Twin_Shop__Web_API.DTOs.Product;
using Twin_Shop__Web_API.Entities;
using TwinShop.Shared;
using TwinShop.Shared.ViewModels;


namespace Twin_Shop__Web_API.Services.Interfaces
{
    public interface IProductService
    {
        Task<OperationResult<List<ProductCardViewModel>>> GetAllProductsAsync();
        Task<OperationResult<ProductDto>> GetProductByIdAsync(int id);
        Task<OperationResult<List<ProductDto>>> GetProductsByNameAsync(string name);
        Task<OperationResult<List<ProductDto>>> GetProductsByBrandNameAsync(string brandName);
        Task<OperationResult<List<ProductDto>>> GetProductsByCategoryNameAsync(string categoryName);
        Task<OperationResult> CreateProductAsync(ProductCardViewModel productView);
        Task<OperationResult> DeleteProductAsync(int id);
        Task<OperationResult> UpdateProductAsync(ProductCardViewModel productView, int id);
        Task<OperationResult<List<ProductCardViewModel>>> SearchProductsAsync(string searchTerm);
    }
}
