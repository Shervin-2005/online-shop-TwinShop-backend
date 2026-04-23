using Twin_Shop__Web_API.DTOs.Category;
using Twin_Shop__Web_API.Entities;
using TwinShop.Shared;
using TwinShop.Shared.ViewModels;


namespace Twin_Shop__Web_API.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<OperationResult<List<CategoryViewModel>>> GetAllCategoriesAsync();
        Task<OperationResult<CategoryDto>> GetCategoryByIdAsync(int id);
        Task<OperationResult<int>> GetCategoryByNameAsync(string name);
        Task<OperationResult<List<CategoryDto>>> GetCategoriesByNameAsync(string name);
        Task<OperationResult> CreateCategoryAsync(CategoryViewModel categoryView);
        Task<OperationResult> DeleteCategoryAsync(int id);
        Task<OperationResult> UpdateCategoryAsync(CategoryViewModel categoryViewModel, int id);
        Task<OperationResult<List<CategoryViewModel>>> SearchCategoriesAsync(string searchTerm);

    }
}