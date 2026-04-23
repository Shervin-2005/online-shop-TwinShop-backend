using AutoMapper;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using Twin_Shop__Web_API.DTOs.Brand;
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
    public class BrandService : IBrandService
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IErrorService _errorService;
        private readonly ICategoryRepository _categoryRepository;

        public BrandService(IErrorService errorService, IBrandRepository brandRepository, ICategoryRepository categoryRepository)
        {
            _brandRepository = brandRepository;
            _errorService = errorService;
            _categoryRepository = categoryRepository;
        }

        public async Task<OperationResult<List<BrandViewModel>>> GetAllBrandsAsync()
        {
            var brandsResult = await _brandRepository.GetAllAsync();
            if (!brandsResult.Success)
            {
                var error = brandsResult.Exception!.ExceptionToErrorDTO(brandsResult.Message!);
                var errorLog = await _errorService.LogErrorAsync(error);
                return OperationResult<List<BrandViewModel>>.Failed(errorLog.Message!.ErrorMessage());
            }
            var brands = BrandMapper.BrandDTOToBrandViewModel(brandsResult.Data);
            return OperationResult<List<BrandViewModel>>.SuccessedResult(brands);
        }

        public async Task<OperationResult<BrandDto>> GetBrandByIdAsync(int id)
        {
            var result = await _brandRepository.GetByIdAsync(id);
            if (!result.Success)
            {
                var error = result.Exception!.ExceptionToErrorDTO(result.Message!);
                var resultError = await _errorService.LogErrorAsync(error);
                return OperationResult<BrandDto>.Failed(resultError.Message!.ErrorMessage());
            }
            return result;
        }
        

        public async Task<OperationResult> CreateBrandAsync(BrandViewModel brandViewModel)
        {
            if (!brandViewModel.IsValid)
                return OperationResult.Failed(brandViewModel.ErrorMessage);

            var isNameExist = await _brandRepository
                                        .BrandNameExist(brandViewModel.BrandName!);
            if (isNameExist.Success)
            {
                return OperationResult.Failed(MessagesAndConsts.BrandNameAlreadyExist);
            }

            if (!brandViewModel.MainImage!.Contains(MessagesAndConsts.Url))
            {
                using var savePhoto = new SavePhoto();
                var savingPhoto = await savePhoto.SaveBrandMainAsync(brandViewModel.MainImage!, brandViewModel.BrandName!);
                if (!savingPhoto.Success)
                {
                    var error = savingPhoto.Exception!.ExceptionToErrorDTO(savingPhoto.Message!);
                    var errorLog = await _errorService.LogErrorAsync(error);
                    return OperationResult.Failed(errorLog.Message!.ErrorMessage());
                }

                brandViewModel.MainImage = savingPhoto.Message;
            }
            var isCategoryExist= await _categoryRepository.CategoryNameExist(brandViewModel.CategoryName!);
            if (!isCategoryExist.Success)
            {
                return OperationResult.Failed(MessagesAndConsts.CategoryNameNotExisted);
            }
            var CategoryIdResult = await _categoryRepository.GetCateogryByNameAsync(brandViewModel.CategoryName!);

            brandViewModel.CategoryId = CategoryIdResult.Data;

            BrandDto brandDto = brandViewModel.BrandViewModelToBrandDTO();
            var result = await _brandRepository.InsertAsync(brandDto);
            if (!result.Success)
            {
                var error = result.Exception!.ExceptionToErrorDTO(result.Message!);
                var result1 = await _errorService.LogErrorAsync(error);
                return OperationResult.Failed(result1.Message!.ErrorMessage());
            }
            return OperationResult.SuccessedResult(true, MessagesAndConsts.BrandAdded);
        }
        public async Task<OperationResult> DeleteBrandAsync(int id)
        {
            var result = await _brandRepository.DeleteAsync(id);
            if (!result.Success)
            {
                var error = result.Exception!.ExceptionToErrorDTO(result.Message!);
                var errorResult = await _errorService.LogErrorAsync(error);
                return OperationResult.Failed(errorResult.Message!.ErrorMessage());
            }
            return OperationResult.SuccessedResult(true, MessagesAndConsts.DeleteBrand);
        }

        public async Task<OperationResult> UpdateBrandAsync(BrandViewModel brandViewModel,int id)
        {
             if (!brandViewModel.IsValid)
                return OperationResult.Failed(brandViewModel.ErrorMessage);

            var isNameExist = await _brandRepository
                                        .BrandNameExist(brandViewModel.BrandName!);

            if (isNameExist.Success)
            {
                return OperationResult.Failed(MessagesAndConsts.BrandNameAlreadyExist);
            }

            if (!brandViewModel.MainImage!.Contains(MessagesAndConsts.Url))
            {
                using var savePhoto = new SavePhoto();
                var savingPhoto = await savePhoto.SaveBrandMainAsync(brandViewModel.MainImage!, brandViewModel.BrandName!);
                if (!savingPhoto.Success)
                {
                    var error = savingPhoto.Exception!.ExceptionToErrorDTO(savingPhoto.Message!);
                    var result = await _errorService.LogErrorAsync(error);
                    return OperationResult.Failed(result.Message!.ErrorMessage());
                }
                brandViewModel.MainImage = savingPhoto.Message;
            }
            var isCategoryExist = await _categoryRepository.CategoryNameExist(brandViewModel.CategoryName!);
            if (!isCategoryExist.Success)
            {
                return OperationResult.Failed(MessagesAndConsts.CategoryNameNotExisted);
            }
            var CategoryIdResult = await _categoryRepository.GetCateogryByNameAsync(brandViewModel.CategoryName!);

            brandViewModel.CategoryId = CategoryIdResult.Data;

            BrandDto brandDto = brandViewModel.BrandViewModelToBrandDTO();
                var resultUpdate = await _brandRepository.UpdateAsync(brandDto, id);
                if (!resultUpdate.Success)
                {
                    var error = resultUpdate.Exception!.ExceptionToErrorDTO(resultUpdate.Message!);
                    var eroorResult = await _errorService.LogErrorAsync(error);
                    return eroorResult;
                }
                return OperationResult.SuccessedResult(true, MessagesAndConsts.update);
        }

        public async Task<OperationResult<List<BrandDto>>> GetBrandsByNameAsync(string name)
        {
            var result = await _brandRepository.GetBrandsByNameAsync(name);
            if (!result.Success)
            {
                var error = result.Exception!.ExceptionToErrorDTO(result.Message!);
                var errorResult = await _errorService.LogErrorAsync(error);
                return OperationResult<List<BrandDto>>.Failed(errorResult.Message!.ErrorMessage());
            }
            return OperationResult<List<BrandDto>>.SuccessedResult(result.Data);
        }

        public async Task<OperationResult<List<BrandDto>>> GetBrandsByCategoryNameAsync(string categoryName)
        {
            var result = await _brandRepository.GetBrandsByCategoryNameAsync(categoryName);
            if (!result.Success)
            {
                var error = result.Exception!.ExceptionToErrorDTO(result.Message!);
                var errorResult = await _errorService.LogErrorAsync(error);
                return OperationResult<List<BrandDto>>.Failed(errorResult.Message!.ErrorMessage());
            }
            return OperationResult<List<BrandDto>>.SuccessedResult(result.Data);
        }
        public async Task<OperationResult<List<BrandViewModel>>> SearchBrandsAsync(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return await GetAllBrandsAsync ();

            var result = await _brandRepository.SearhBrandByName(searchTerm);
            if (!result.Success)
            {
                var error = result.Exception!.ExceptionToErrorDTO(result.Message!);
                var errorLog = await _errorService.LogErrorAsync(error);
                return OperationResult<List<BrandViewModel>>.Failed(errorLog.Message!.ErrorMessage());
            }

            var brands = BrandMapper.BrandDTOToBrandViewModel(result.Data);
            return OperationResult<List<BrandViewModel>>.SuccessedResult(brands);
        }
    }

}
