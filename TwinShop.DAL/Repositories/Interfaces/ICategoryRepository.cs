using Twin_Shop__Web_API.DTOs.Category;
using Twin_Shop__Web_API.Entities;
using TwinShop.Shared;

namespace TwinShop.DAL.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        Task<bool> DeleteAsync(int id);
        Task<List<CategoryDto>> GetAllAsync();
        Task<CategoryDto?> GetByIdAsync(int categoryId);
        Task<List<CategoryDto>> SearchCategoriesAsync(string categoryName);
        Task<int> InsertAsync(CategoryDto categoryDto);
        Task<bool> UpdateAsync(CategoryDto categoryDto, int id);
        Task<bool> CategoryNameExistsAsync(string categoryName);
        Task<int?> GetCategoryIdByNameAsync(string categoryName);
        Task<bool> CategoryIdExistsAsync(int categoryId);
    }
}
   
