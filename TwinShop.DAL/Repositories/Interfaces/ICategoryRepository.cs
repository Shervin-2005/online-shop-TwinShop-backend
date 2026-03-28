using Twin_Shop__Web_API.DTOs.Category;
using Twin_Shop__Web_API.Entities;
using TwinShop.Shared;

namespace TwinShop.DAL.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        public Task<OperationResult> InsertAsync(CategoryDto categoryDto);
        public Task<OperationResult> DeleteAsync(int id);
        public Task<OperationResult> UpdateAsync(CategoryDto categoryDto, int id);
        public Task<OperationResult<List<CategoryDto>>> GetCategoriesByNameAsync(string CategoryName);
        public Task<OperationResult<CategoryDto>> GetByIdAsync(int CategoryId);
        public Task<OperationResult<List<CategoryDto>>> GetAllAsync();
    }
}
   
