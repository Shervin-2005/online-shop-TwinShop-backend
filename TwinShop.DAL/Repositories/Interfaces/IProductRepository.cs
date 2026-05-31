using Twin_Shop__Web_API.DTOs.Product;
using Twin_Shop__Web_API.Entities;
using TwinShop.Shared;

namespace TwinShop.DAL.Repositories.Interfaces
{
    public interface IProductRepository 
    {
        Task<bool> DeleteAsync(int id);
        Task<List<ProductDto>> GetAllAsync();
        Task<ProductDto?> GetByIdAsync(int productId);
        Task<List<ProductDto>> GetProductsByCategoryNameAsync(string categoryName);
        Task<int> InsertAsync(ProductDto productDto);
        Task<bool> UpdateAsync(ProductDto productDto, int id);
        Task<bool> ProductNameExistAsync(string name);
        Task<List<ProductDto>> SearchProductByNameAsync(string searchTerm);
        Task<int?> GetProductIdByNameAsync(string productName);
    }
}
