using AutoMapper;
using Microsoft.Extensions.Logging;
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
namespace Twin_Shop__Web_API.Services.Implementations;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IErrorService _errorService;

    public ProductService(IErrorService errorService,IProductRepository productRepository)
    {
        _errorService = errorService;
        _productRepository =  productRepository;   
    }
    public async Task<OperationResult<ProductDto>> GetProductByIdAsync(int id)
    {
        var result = await _productRepository.GetByIdAsync(id);
        if (!result.Success)
        {
            var error = result.Exception!.ExceptionToErrorDTO(result.Message!);
            var resultError = await _errorService.LogErrorAsync(error);
            return OperationResult<ProductDto>.Failed(resultError.Message!.ErrorMessage());
        }
        return result;
    }

    public async Task<OperationResult> CreateProductAsync(ProductViewModel productView)
    {
        if(!productView.IsValid)
            return OperationResult.Failed(productView.ErrorMessage);
        //نوشتن نحوه اضافه کردن عکس با حسین
        ProductDto productDto = productView.ToProductDTO();
            var result= await _productRepository.InsertAsync(productDto);
        if (!result.Success)
            {
                var error = result.Exception!.ExceptionToErrorDTO(result.Message!);
                var result1 = await _errorService.LogErrorAsync(error);
                return OperationResult.Failed(result1.Message!.ErrorMessage());
            }
        return OperationResult.SuccessedResult(true, MessagesAndConsts.ProductAdded);
    }

    public async Task<OperationResult<List<ProductDto>>> GetAllProductsAsync()
    {
        var result = await _productRepository.GetAllAsync();
        if (!result.Success)
        {
            var error = result.Exception!.ExceptionToErrorDTO(result.Message!);
            var resulterror = await _errorService.LogErrorAsync(error);
            return OperationResult<List<ProductDto>>.Failed(resulterror.Message!.ErrorMessage());
        }
        return result;
    }

    public async Task<OperationResult> DeleteProductAsync(int id)
    {
        var result = await _productRepository.DeleteAsync(id);
        if (!result.Success)
        {
            var error = result.Exception!.ExceptionToErrorDTO(result.Message!);
            var errorResult = await _errorService.LogErrorAsync(error);
            return OperationResult.Failed(errorResult.Message!.ErrorMessage());
        }
        return OperationResult.SuccessedResult(true, MessagesAndConsts.DeleteProduct);
    }   
    

    public async Task<OperationResult> UpdateProductAsync(ProductViewModel productView, int id)
    {
        if (!productView.IsValid)
            return OperationResult.Failed(productView.ErrorMessage);
        if (productView.MainImage!.Contains(MessagesAndConsts.Url))
        {
            ProductDto productDto = productView.ToProductDTO();
            var resultUpdate = await _productRepository.UpdateAsync(productDto,id);
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
    public async Task<OperationResult<List<ProductDto>>> GetProductsByNameAsync(string name)
    {
        var result = await _productRepository.GetProductsByNameAsync(name);
        if (!result.Success)
        {
            var error = result.Exception!.ExceptionToErrorDTO(result.Message!);
            var errorResult = await _errorService.LogErrorAsync(error);
            return OperationResult<List<ProductDto>>.Failed(errorResult.Message!.ErrorMessage());
        }
        return OperationResult<List<ProductDto>>.SuccessedResult(result.Data);
    }

    public async Task<OperationResult<List<ProductDto>>> GetProductsByBrandNameAsync(string brandName)
    {
        var result = await _productRepository.GetProductsByBrandNameAsync(brandName);
        if (!result.Success)
        {
            var error = result.Exception!.ExceptionToErrorDTO(result.Message!);
            var errorResult = await _errorService.LogErrorAsync(error);
            return OperationResult<List<ProductDto>>.Failed(errorResult.Message!.ErrorMessage());
        }
        return OperationResult<List<ProductDto>>.SuccessedResult(result.Data);
    }

    public async Task<OperationResult<List<ProductDto>>> GetProductsByCategoryNameAsync(string categoryName)
    {
        var result = await _productRepository.GetProductsByCategoryNameAsync(categoryName);
        if (!result.Success)
        {
            var error = result.Exception!.ExceptionToErrorDTO(result.Message!);
            var errorResult = await _errorService.LogErrorAsync(error);
            return OperationResult<List<ProductDto>>.Failed(errorResult.Message!.ErrorMessage());
        }
        return OperationResult<List<ProductDto>>.SuccessedResult(result.Data);
    }
}
