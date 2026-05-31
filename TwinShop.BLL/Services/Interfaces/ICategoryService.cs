using Microsoft.AspNetCore.Http;
using Twin_Shop__Web_API.DTOs.Category;
using Twin_Shop__Web_API.Entities;
using TwinShop.Shared;
using TwinShop.Shared.ViewModels;


namespace Twin_Shop__Web_API.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<List<CategoryViewModel>> GetAllCategoriesAsync();
        Task<CategoryViewModel> GetCategoryByIdAsync(int id);
        Task<int> CreateCategoryAsync(CategoryViewModel categoryViewModel);
        Task DeleteCategoryAsync(int id);
        Task UpdateCategoryAsync(CategoryViewModel categoryViewModel, int id);
        Task<List<CategoryViewModel>> SearchCategoriesAsync(string searchTerm);
    }
}