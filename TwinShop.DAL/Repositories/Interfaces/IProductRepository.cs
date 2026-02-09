using Twin_Shop__Web_API.Entities;

namespace Twin_Shop__Web_API.Repositories.Interfaces
{
    public interface IProductRepository 
    {
        public Task<bool> InsertAsync(Product product);
        public Task<bool> DeleteAsync(int id);
        public Task<bool> UpdateAsync(Product product);
        public Task<List<Product>> GetProductsByNameAsync(string ProductName);
        public Task<List<Product>> GetProductsByBrandAsync(int brandId);
        public Task<List<Product>> GetByIdAsync(int ProductId);
        public Task<List<Product>> GetAllAsync();


    }
}
