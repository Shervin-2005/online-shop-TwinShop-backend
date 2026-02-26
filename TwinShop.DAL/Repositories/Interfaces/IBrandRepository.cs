using Twin_Shop__Web_API.Entities;

namespace TwinShop.DAL.Repositories.Interfaces
{
    public interface IBrandRepository
    {
        public Task<bool> InsertAsync(Brand brand);
        public Task<bool> DeleteAsync(int id);
        public Task<bool> UpdateAsync(Brand brand);
        public Task<List<Brand?>> GetBrandsByNameAsync(string brandName);
        public Task<List<Brand?>> GetBrandsByCategoryNameAsync(string categoryName);
        public Task<Brand> GetByIdAsync(int brandId);
        public Task<List<Brand>> GetAllAsync();

    }
}
