using TwinShop.BLL.Services.Interfaces;
using TwinShop.DAL.Repositories.Interfaces;
using TwinShop.Shared.Custom_Exceptions;
using TwinShop.Shared.DTOS;
using TwinShop.Shared.ViewModels;

namespace TwinShop.BLL.Services.Implementations
{
    public class CategoryValidationService : ICategoryValidationService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryValidationService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task ValidateCategoryAsync(CategoryViewModel categoryViewModel)
        {
            if (!categoryViewModel.IsValid)
                throw new ValidationException(new List<string> { categoryViewModel.ErrorMessage });

            if (await _categoryRepository.CategoryNameExistsAsync(categoryViewModel.CategoryName!))
                throw new BadRequestException(MessagesAndConsts.CategoryNameAlreadyExist);

        }
    }
}
