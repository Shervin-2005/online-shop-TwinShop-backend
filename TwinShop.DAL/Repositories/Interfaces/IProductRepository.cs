using Twin_Shop__Web_API.DTOs.Product;
using Twin_Shop__Web_API.Entities;
using TwinShop.Shared;

namespace TwinShop.DAL.Repositories.Interfaces
{
    public interface IProductRepository 
    {
        public Task<OperationResult> InsertAsync(ProductDto product);
        public Task<OperationResult> DeleteAsync(int id);
        public Task<OperationResult> UpdateAsync(ProductDto product,int id);
        public Task<OperationResult<List<ProductDto>>> GetProductsByNameAsync(string productName);
        public Task<OperationResult<List<ProductDto>>> GetProductsByBrandNameAsync(string brandName);
        public Task<OperationResult<List<ProductDto>>> GetProductsByCategoryNameAsync(string categoryName);
        public Task<OperationResult<ProductDto>> GetByIdAsync(int productId);
        public Task<OperationResult<List<ProductDto>>> GetAllAsync();
    }
}
