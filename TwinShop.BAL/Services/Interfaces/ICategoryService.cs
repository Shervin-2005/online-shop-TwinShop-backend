using Twin_Shop__Web_API.DTOs.Category;
using Twin_Shop__Web_API.Entities;


namespace Twin_Shop__Web_API.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<List<CategoryDto>> GetAllCategoriesAsync();
        Task<CategoryDto?> GetCategoryByIdAsync(int id);
        Task<List<CategoryDto?>> GetCategoriesByNameAsync(string name);
        Task<CategoryDto> CreateCategoryAsync(CreateCategoryDto dto);
        Task<bool> DeleteCategoryAsync(int id);
        Task<bool> UpdateCategoryAsync(UpdateCategoryDto dto);

    }
}