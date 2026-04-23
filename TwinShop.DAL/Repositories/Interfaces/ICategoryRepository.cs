using Twin_Shop__Web_API.DTOs.Category;
using Twin_Shop__Web_API.Entities;
using TwinShop.Shared;

namespace TwinShop.DAL.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        Task<OperationResult> InsertAsync(CategoryDto categoryDto);
        Task<OperationResult> DeleteAsync(int id);
        Task<OperationResult> UpdateAsync(CategoryDto categoryDto, int id);
        Task<OperationResult<List<CategoryDto>>> GetCategoriesByNameAsync(string CategoryName);
        Task<OperationResult<int>> GetCateogryByNameAsync(string categoryName);
        Task<OperationResult<CategoryDto>> GetByIdAsync(int CategoryId);
        Task<OperationResult<List<CategoryDto>>> GetAllAsync();
        Task<OperationResult> CategoryNameExist(string Name);
        Task<OperationResult<List<CategoryDto>>> SearhCategoryByName(string searchTerm);
    }
}
   
