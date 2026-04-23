using Twin_Shop__Web_API.DTOs.Product;
using Twin_Shop__Web_API.Entities;
using TwinShop.Shared;

namespace TwinShop.DAL.Repositories.Interfaces
{
    public interface IProductRepository 
    {
        Task<OperationResult> InsertAsync(ProductDto product);
        Task<OperationResult> DeleteAsync(int id);
        Task<OperationResult> UpdateAsync(ProductDto product,int id);
        Task<OperationResult<List<ProductDto>>> GetProductsByNameAsync(string productName);
        Task<OperationResult<List<ProductDto>>> GetProductsByBrandNameAsync(string brandName);
        Task<OperationResult<List<ProductDto>>> GetProductsByCategoryNameAsync(string categoryName);
        Task<OperationResult<ProductDto>> GetByIdAsync(int productId);
        Task<OperationResult<List<ProductDto>>> GetAllAsync();
        Task<OperationResult> ProductNameExist(string Name);
        Task<OperationResult<List<ProductDto>>> SearhProductByName(string searchTerm);
        Task<OperationResult<int>>GetProductIdByName(string productName);
    }
}
