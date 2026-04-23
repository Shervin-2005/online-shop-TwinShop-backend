using AutoMapper;
using Microsoft.Extensions.Logging;
using Twin_Shop__Web_API.DTOs.Category;
using Twin_Shop__Web_API.DTOs.Product;
using Twin_Shop__Web_API.Entities;
using Twin_Shop__Web_API.Services.Interfaces;
using TwinShop.BLL.Services.Interfaces;
using TwinShop.DAL.Repositories.Implementations;
using TwinShop.DAL.Repositories.Interfaces;
using TwinShop.Shared;
using TwinShop.Shared.DTOS;
using TwinShop.Shared.ErrorHandling;
using TwinShop.Shared.Mappers;
using TwinShop.Shared.ViewModels;
using TwinShop.Shared.ViewModels.UserViewModels;
namespace Twin_Shop__Web_API.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IErrorService _errorService;
        public CategoryService(ICategoryRepository categoryRepository,IErrorService errorService)
        {
            _categoryRepository = categoryRepository;
            _errorService = errorService;
        }
        public async Task<OperationResult<List<CategoryViewModel>>> GetAllCategoriesAsync()
        {
            var categoriesResult = await _categoryRepository.GetAllAsync();
            if (!categoriesResult.Success)
            {
                var error = categoriesResult.Exception!.ExceptionToErrorDTO(categoriesResult.Message!);
                var errorLog = await _errorService.LogErrorAsync(error);
                return OperationResult<List<CategoryViewModel>>.Failed(errorLog.Message!.ErrorMessage());
            }
            var categories = CategoryMapper.CategoryDTOToCategoryCardViewModel(categoriesResult.Data);
            return OperationResult<List<CategoryViewModel>>.SuccessedResult(categories);
        }

        public async Task<OperationResult<CategoryDto>> GetCategoryByIdAsync(int id)
        {
            var result = await _categoryRepository.GetByIdAsync(id);
            if (!result.Success)
            {
                var error = result.Exception!.ExceptionToErrorDTO(result.Message!);
                var resultError = await _errorService.LogErrorAsync(error);
                return OperationResult<CategoryDto>.Failed(resultError.Message!.ErrorMessage());
            }
            return result;

        }

        public async Task<OperationResult> CreateCategoryAsync(CategoryViewModel categoryCardViewModel)
        {
            if (!categoryCardViewModel.IsValid)
                return OperationResult.Failed(categoryCardViewModel.ErrorMessage);

            var isNameExist = await _categoryRepository
                                        .CategoryNameExist(categoryCardViewModel.CategoryName!);
            if (isNameExist.Success)
            {
                return OperationResult.Failed(MessagesAndConsts.CategoryNameAlreadyExist);
            }

            if (!categoryCardViewModel.MainImage!.Contains(MessagesAndConsts.Url))
            {
                using var savePhoto = new SavePhoto();
                var savingPhoto = await savePhoto.SaveCategoryMainAsync(categoryCardViewModel.MainImage!, categoryCardViewModel.CategoryName!);
                if (!savingPhoto.Success)
                {
                    var error = savingPhoto.Exception!.ExceptionToErrorDTO(savingPhoto.Message!);
                    var errorLog = await _errorService.LogErrorAsync(error);
                    return OperationResult.Failed(errorLog.Message!.ErrorMessage());
                }

                categoryCardViewModel.MainImage = savingPhoto.Message;
            }
            CategoryDto categoryDto = categoryCardViewModel.CategoryCardViewModelToCategoryDTO();
            var result = await _categoryRepository.InsertAsync(categoryDto);
            if (!result.Success)
            {
                var error = result.Exception!.ExceptionToErrorDTO(result.Message!);
                var result1 = await _errorService.LogErrorAsync(error);
                return OperationResult.Failed(result1.Message!.ErrorMessage());
            }
            return OperationResult.SuccessedResult(true, MessagesAndConsts.CategoryAdded);
        }

        public async Task<OperationResult> DeleteCategoryAsync(int id)
        {
            var result = await _categoryRepository.DeleteAsync(id);
            if (!result.Success)
            {
                var error = result.Exception!.ExceptionToErrorDTO(result.Message!);
                var errorResult = await _errorService.LogErrorAsync(error);
                return OperationResult.Failed(errorResult.Message!.ErrorMessage());
            }
            return OperationResult.SuccessedResult(true, MessagesAndConsts.DeleteCategory);
        }

        public async Task<OperationResult> UpdateCategoryAsync(CategoryViewModel categoryCardViewModel,int id )
        {
            if (!categoryCardViewModel.IsValid)
                return OperationResult.Failed(categoryCardViewModel.ErrorMessage);
            if (!categoryCardViewModel.MainImage!.Contains(MessagesAndConsts.Url))
            {
                using var savePhoto = new SavePhoto();
                var savingPhoto = await savePhoto.SaveCategoryMainAsync(categoryCardViewModel.MainImage!, categoryCardViewModel.CategoryName!);
                if (!savingPhoto.Success)
                {
                    var error = savingPhoto.Exception!.ExceptionToErrorDTO(savingPhoto.Message!);
                    var result = await _errorService.LogErrorAsync(error);
                    return OperationResult.Failed(result.Message!.ErrorMessage());
                }

                categoryCardViewModel.MainImage = savingPhoto.Message;
            }

            CategoryDto categoryDto = categoryCardViewModel.CategoryCardViewModelToCategoryDTO();
            var resultUpdate = await _categoryRepository.UpdateAsync(categoryDto, id);
            if (!resultUpdate.Success)
            {
                var error = resultUpdate.Exception!.ExceptionToErrorDTO(resultUpdate.Message!);
                var eroorResult = await _errorService.LogErrorAsync(error);
                return eroorResult;
            }
            return OperationResult.SuccessedResult(true, MessagesAndConsts.update);
        }
        

        public async Task<OperationResult<List<CategoryDto>>> GetCategoriesByNameAsync(string name)
        {
            var result = await _categoryRepository.GetCategoriesByNameAsync(name);
            if (!result.Success)
            {
                var error = result.Exception!.ExceptionToErrorDTO(result.Message!);
                var errorResult = await _errorService.LogErrorAsync(error);
                return OperationResult<List<CategoryDto>>.Failed(errorResult.Message!.ErrorMessage());
            }
            return OperationResult<List<CategoryDto>>.SuccessedResult(result.Data);
        }
        public async Task<OperationResult<int>> GetCategoryByNameAsync(string name)
        {
            var resultId = await _categoryRepository.GetCateogryByNameAsync(name);
            if (!resultId.Success)
            {
                var error = resultId.Exception!.ExceptionToErrorDTO(resultId.Message!);
                var errorLog = await _errorService.LogErrorAsync(error);
                return OperationResult<int>.Failed(errorLog.Message!.ErrorMessage());
            }
            return OperationResult<int>.SuccessedResult(resultId.Data);
        }
        public async Task<OperationResult<List<CategoryViewModel>>> SearchCategoriesAsync(string searchTerm)
        {
            if(string.IsNullOrWhiteSpace(searchTerm))
                return await GetAllCategoriesAsync();

            var result = await _categoryRepository.SearhCategoryByName(searchTerm);
            if (!result.Success)
            {
                var error = result.Exception!.ExceptionToErrorDTO(result.Message!);
                var errorLog = await _errorService.LogErrorAsync(error);
                return OperationResult<List<CategoryViewModel>>.Failed(errorLog.Message!.ErrorMessage());
            }

            var categories = CategoryMapper.CategoryDTOToCategoryCardViewModel(result.Data);
            return OperationResult<List<CategoryViewModel>>.SuccessedResult(categories);
        }
    }
}


