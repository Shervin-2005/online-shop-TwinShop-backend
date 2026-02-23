using Twin_Shop__Web_API.Entities;

namespace TwinShop.DAL.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        public Task<bool> InsertAsync(Category category);
        public Task<bool> DeleteAsync(int id);
        public Task<bool> UpdateAsync(Category category);
        public Task<List<Category?>> GetCategoriesByNameAsync(string categoryName);
        public Task<Category> GetByIdAsync(int categoryId);
        public Task<List<Category>> GetAllAsync();
    }
}
   
