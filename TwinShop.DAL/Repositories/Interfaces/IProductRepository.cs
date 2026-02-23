using Twin_Shop__Web_API.Entities;

namespace TwinShop.DAL.Repositories.Interfaces
{
    public interface IProductRepository 
    {
        public Task<bool> InsertAsync(Product product);
        public Task<bool> DeleteAsync(int id);
        public Task<bool> UpdateAsync(Product product);
        public Task<List<Product?>> GetProductsByNameAsync(string productName);
        public Task<List<Product>> GetProductsByBrandAsync(int brandId);
        public Task<Product?> GetByIdAsync(int productId);
        public Task<List<Product>> GetAllAsync();
    }
}
