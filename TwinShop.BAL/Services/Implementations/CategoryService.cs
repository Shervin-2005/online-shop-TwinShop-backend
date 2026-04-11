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
        public async Task<OperationResult<List<CategoryDto>>> GetAllCategoriesAsync()
        {
            var result = await _categoryRepository.GetAllAsync();
            if (!result.Success)
            {
                var error = result.Exception!.ExceptionToErrorDTO(result.Message!);
                var resulterror = await _errorService.LogErrorAsync(error);
                return OperationResult<List<CategoryDto>>.Failed(resulterror.Message!.ErrorMessage());
            }
            return result;
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

        public async Task<OperationResult> CreateCategoryAsync(CategoryViewModel categoryView)
        {
            if (!categoryView.IsValid)
                return OperationResult.Failed(categoryView.ErrorMessage);
            //نوشتن نحوه اضافه کردن عکس با حسین
            CategoryDto categoryDto = categoryView.ToCategoryDTO();
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

        public async Task<OperationResult> UpdateCategoryAsync(CategoryViewModel categoryViewModel,int id )
        {
            if (!categoryViewModel.IsValid)
                return OperationResult.Failed(categoryViewModel.ErrorMessage);
            if (categoryViewModel.MainImage!.Contains(MessagesAndConsts.Url))
            {
                CategoryDto categoryDto = categoryViewModel.ToCategoryDTO();
                var resultUpdate = await _categoryRepository.UpdateAsync(categoryDto, id);
                if (!resultUpdate.Success)
                {
                    var error = resultUpdate.Exception!.ExceptionToErrorDTO(resultUpdate.Message!);
                    var eroorResult = await _errorService.LogErrorAsync(error);
                    return eroorResult;
                }
                return OperationResult.SuccessedResult(true, MessagesAndConsts.update);
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
    }
}


