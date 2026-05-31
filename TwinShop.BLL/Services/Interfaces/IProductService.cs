using Microsoft.AspNetCore.Http;
using Twin_Shop__Web_API.DTOs.Category;
using Twin_Shop__Web_API.DTOs.Product;
using Twin_Shop__Web_API.Entities;
using TwinShop.Shared;
using TwinShop.Shared.ViewModels;


namespace Twin_Shop__Web_API.Services.Interfaces
{
    public interface IProductService
    {
        Task<List<ProductCardViewModel>> GetAllProductsAsync();
        Task<ProductCardViewModel> GetProductByIdAsync(int id);
        Task<List<ProductCardViewModel>> GetProductsByCategoryNameAsync(string categoryName);
        Task<int> CreateProductAsync(ProductCardViewModel productViewModel);
        Task DeleteProductAsync(int id);
        Task UpdateProductAsync(ProductCardViewModel productViewModel, int id);
        Task<List<ProductCardViewModel>> SearchProductsAsync(string searchTerm);
    }
}
