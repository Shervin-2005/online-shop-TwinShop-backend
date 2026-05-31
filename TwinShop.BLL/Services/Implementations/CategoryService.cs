using Microsoft.AspNetCore.Http;
using Twin_Shop__Web_API.DTOs.Category;
using Twin_Shop__Web_API.Services.Interfaces;
using TwinShop.BLL.Services.Interfaces;
using TwinShop.BLL.Services.UploadImageService.Interfaces;
using TwinShop.DAL.Repositories.Interfaces;
using TwinShop.Shared.Custom_Exceptions;
using TwinShop.Shared.Mappers;
using TwinShop.Shared.ViewModels;
namespace Twin_Shop__Web_API.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ICategoryValidationService _categoryValidationService;
        private readonly ISaveCategoryImageService _saveCategoryImageService;
        public CategoryService(ICategoryRepository categoryRepository,
                               ICategoryValidationService categoryValidationService,
                               ISaveCategoryImageService saveCategoryImageService)
        {
            _categoryRepository = categoryRepository;
            _categoryValidationService = categoryValidationService;
            _saveCategoryImageService = saveCategoryImageService;
        }
        public async Task<List<CategoryViewModel>> GetAllCategoriesAsync()
        {
           var categories = await _categoryRepository.GetAllAsync();
            return categories.CategoryDTOToCategoryCardViewModel();
        }

        public async Task<CategoryViewModel> GetCategoryByIdAsync(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);

            if (category == null)
                throw new NotFoundException("Category", id);

            return category.CategoryDTOToCategoryCardViewModel();
        }

        public async Task<int> CreateCategoryAsync(CategoryViewModel categoryViewModel)
        {
           await _categoryValidationService.ValidateCategoryAsync(categoryViewModel);

            string imageUrl = await _saveCategoryImageService.UploadCategoryImage(categoryViewModel.Image, categoryViewModel.CategoryName!);

            CategoryDto categoryDto = categoryViewModel.CategoryCardViewModelToCategoryDTO();

            categoryDto.MainImageUrl = imageUrl;

            var categoryId = await _categoryRepository.InsertAsync(categoryDto);

            return categoryId;
        }

        public async Task DeleteCategoryAsync(int id)
        {
            if (!await _categoryRepository.DeleteAsync(id))
                throw new NotFoundException("Category", id);
        }

        public async Task UpdateCategoryAsync(CategoryViewModel categoryViewModel, int id)
        {
            await _categoryValidationService.ValidateCategoryAsync(categoryViewModel);

            string imageUrl = await _saveCategoryImageService.UploadCategoryImage(categoryViewModel.Image, categoryViewModel.CategoryName!);

            CategoryDto categoryDto = categoryViewModel.CategoryCardViewModelToCategoryDTO();

            categoryDto.MainImageUrl = imageUrl;

            var categoryId = await _categoryRepository.UpdateAsync(categoryDto,id);
        }

        public async Task<List<CategoryViewModel>> SearchCategoriesAsync(string searchTerm)
        {
           if(string.IsNullOrWhiteSpace(searchTerm))
                return await GetAllCategoriesAsync();
           var categoryDTOs = await _categoryRepository.SearchCategoriesAsync(searchTerm);
            return categoryDTOs.CategoryDTOToCategoryCardViewModel();
        }
    }
}


