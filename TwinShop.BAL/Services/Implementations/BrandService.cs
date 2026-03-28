using System.Collections.Generic;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Twin_Shop__Web_API.DTOs.Brand;
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

        public BrandService(IErrorService errorService, IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
            _errorService = errorService;
        }

        public async Task<OperationResult<List<BrandDto>>> GetAllBrandsAsync()
        {
            var result = await _brandRepository.GetAllAsync();
            if (!result.Success)
            {
                var error = result.Exception!.ExceptionToErrorDTO(result.Message!);
                var resulterror = await _errorService.LogErrorAsync(error);
                return OperationResult<List<BrandDto>>.Failed(resulterror.Message!.ErrorMessage());
            }
            return result;
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
        

        public async Task<OperationResult> CreateBrandAsync(BrandViewModel brandView)
        {
            if (!brandView.IsValid)
                return OperationResult.Failed(brandView.ErrorMessage);
            //نوشتن نحوه اضافه کردن عکس با حسین
            BrandDto brandDto = brandView.ToBrandDTO();
            var result = await _brandRepository.InsertAsync(brandDto);
            if (!result.Success)
            {
                var error = result.Exception!.ExceptionToErrorDTO(result.Message!);
                var result1 = await _errorService.LogErrorAsync(error);
                return OperationResult.Failed(result1.Message!.ErrorMessage());
            }
            return OperationResult.SuccessedResult(true, Messages.BrandAdded);

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
            return OperationResult.SuccessedResult(true, Messages.DeleteBrand);
        }

        public async Task<OperationResult> UpdateBrandAsync(BrandViewModel brandView,int id)
        {
            if (!brandView.IsValid)
                return OperationResult.Failed(brandView.ErrorMessage);
            if (brandView.MainImage!.Contains(Messages.Url))
            {
                BrandDto brandDto = brandView.ToBrandDTO();
                var resultUpdate = await _brandRepository.UpdateAsync(brandDto, id);
                if (!resultUpdate.Success)
                {
                    var error = resultUpdate.Exception!.ExceptionToErrorDTO(resultUpdate.Message!);
                    var eroorResult = await _errorService.LogErrorAsync(error);
                    return eroorResult;
                }
                return OperationResult.SuccessedResult(true, Messages.update);
            }
            return OperationResult.SuccessedResult(true, Messages.update);
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
    }

}
