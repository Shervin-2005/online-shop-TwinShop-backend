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
using TwinShop.Shared.DTOS.Product;
using TwinShop.Shared.ErrorHandling;
using TwinShop.Shared.Mappers;
using TwinShop.Shared.ViewModels;
namespace Twin_Shop__Web_API.Services.Implementations;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IProductSideImageRepository _productSideImageRepository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IBrandRepository _brandRepository;
    private readonly IErrorService _errorService;

    public ProductService(IErrorService errorService,IProductRepository productRepository
                        ,ICategoryRepository categoryRepository,IBrandRepository brandRepository
                         ,IProductSideImageRepository productSideImageRepository)
    {
        _errorService = errorService;
        _productRepository =  productRepository;   
        _categoryRepository = categoryRepository;
        _brandRepository = brandRepository;
        _productSideImageRepository = productSideImageRepository;
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

    public async Task<OperationResult> CreateProductAsync(ProductCardViewModel productViewModel)
    {

        if (!productViewModel.IsValid)
            return OperationResult.Failed(productViewModel.ErrorMessage);

        var isNameExist = await _productRepository
                                    .ProductNameExist(productViewModel.ProductName!);
        if (isNameExist.Success)
        {
            return OperationResult.Failed(MessagesAndConsts.ProductNameAlreadyExist);
        }

        if (!productViewModel.MainImageUrl!.Contains(MessagesAndConsts.Url))
        {
            using var savePhoto = new SavePhoto();
            var savingPhoto = await savePhoto.SaveProductMainAsync(productViewModel.MainImageUrl!, productViewModel.ProductName!);
            if (!savingPhoto.Success)
            {
                var error = savingPhoto.Exception!.ExceptionToErrorDTO(savingPhoto.Message!);
                var errorLog = await _errorService.LogErrorAsync(error);
                return OperationResult.Failed(errorLog.Message!.ErrorMessage());
            }

            productViewModel.MainImageUrl = savingPhoto.Message;
        }
        var isCategoryExist = await _categoryRepository.CategoryNameExist(productViewModel.CategoryName!);
        if (!isCategoryExist.Success)
        {
            return OperationResult.Failed(MessagesAndConsts.CategoryNameNotExisted);
        }
        var isBrandExist = await _brandRepository.BrandNameExist(productViewModel.BrandName!);
        if (!isBrandExist.Success)
        {
            return OperationResult.Failed(MessagesAndConsts.BrandNameNotExist);
        }
        var CategoryIdResult = await _categoryRepository.GetCateogryByNameAsync(productViewModel.CategoryName!);
        var BrandIdResult = await _brandRepository.GetBrandByNameAsync(productViewModel.BrandName!);

        productViewModel.CategoryId = CategoryIdResult.Data;
        productViewModel.BrandId= BrandIdResult.Data;

        ProductDto productDto = productViewModel.ProductViewModelToProductDTO();
        var result = await _productRepository.InsertAsync(productDto);
        if (!result.Success)
        {
            var error = result.Exception!.ExceptionToErrorDTO(result.Message!);
            var result1 = await _errorService.LogErrorAsync(error);
            return OperationResult.Failed(result1.Message!.ErrorMessage());
        }
        if (productViewModel.SideImageUrls != null && productViewModel.SideImageUrls.Any())
        {
            int productId = productDto.ProductId; 

            using var savePhoto = new SavePhoto();
            foreach (var imagePath in productViewModel.SideImageUrls)
            {
                if (!imagePath.Contains(MessagesAndConsts.Url))
                {
                    var savingResult = await savePhoto.SaveProductGalleryAsync(imagePath, productId);
                    if (savingResult.Success)
                    {
                        var sideImageDto = new ProductSideImageDto
                        {
                            ProductId = productId,
                            SideImageUrl = savingResult.Message
                        };
                        await _productSideImageRepository.InsertSideImagesAsync(sideImageDto);
                    }
                }
            }
        }
        return OperationResult.SuccessedResult(true, MessagesAndConsts.ProductAdded);
    }

    public async Task<OperationResult<List<ProductCardViewModel>>> GetAllProductsAsync()
    {
        var productsResult = await _productRepository.GetAllAsync();
        if (!productsResult.Success)
        {
            var error = productsResult.Exception!.ExceptionToErrorDTO(productsResult.Message!);
            var resultError = await _errorService.LogErrorAsync(error);
            return OperationResult<List<ProductCardViewModel>>.Failed(resultError.Message!.ErrorMessage());
        }
        var Products = ProductMapper.ProductDTOToProductCardViewModel(productsResult.Data);
        return OperationResult<List<ProductCardViewModel>>.SuccessedResult(Products);
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
    

    public async Task<OperationResult> UpdateProductAsync(ProductCardViewModel productViewModel, int id)
    {
        if (!productViewModel.IsValid)
            return OperationResult.Failed(productViewModel.ErrorMessage);
      
        if (!productViewModel.MainImageUrl!.Contains(MessagesAndConsts.Url))
        {
            using var savePhoto = new SavePhoto();
            var savingPhoto = await savePhoto.SaveProductMainAsync(productViewModel.MainImageUrl!, productViewModel.ProductName!);
            if (!savingPhoto.Success)
            {
                var error = savingPhoto.Exception!.ExceptionToErrorDTO(savingPhoto.Message!);
                var result = await _errorService.LogErrorAsync(error);
                return OperationResult.Failed(result.Message!.ErrorMessage());
            }
            productViewModel.MainImageUrl = savingPhoto.Message;
        }
        var isCategoryExist = await _categoryRepository.CategoryNameExist(productViewModel.CategoryName!);
        if (!isCategoryExist.Success)
        {
            return OperationResult.Failed(MessagesAndConsts.CategoryNameNotExisted);
        }
        var isBrandExist = await _brandRepository.BrandNameExist(productViewModel.BrandName!);
        if (!isBrandExist.Success)
        {
            return OperationResult.Failed(MessagesAndConsts.BrandNameNotExist);
        }

        var CategoryIdResult = await _categoryRepository.GetCateogryByNameAsync(productViewModel.CategoryName!);
        var BrandIdResult = await _brandRepository.GetBrandByNameAsync(productViewModel.BrandName!);

        productViewModel.CategoryId = CategoryIdResult.Data;
        productViewModel.BrandId = BrandIdResult.Data;

        ProductDto productDto = productViewModel.ProductViewModelToProductDTO();
        var resultUpdate = await _productRepository.UpdateAsync(productDto, id);
        if (!resultUpdate.Success)
        {
            var error = resultUpdate.Exception!.ExceptionToErrorDTO(resultUpdate.Message!);
            var eroorResult = await _errorService.LogErrorAsync(error);
            return eroorResult;
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
    public async Task<OperationResult<List<ProductCardViewModel>>> SearchProductsAsync(string searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
            return await GetAllProductsAsync();

        var result = await _productRepository.SearhProductByName(searchTerm);
        if (!result.Success)
        {
            var error = result.Exception!.ExceptionToErrorDTO(result.Message!);
            var errorLog = await _errorService.LogErrorAsync(error);
            return OperationResult<List<ProductCardViewModel>>.Failed(errorLog.Message!.ErrorMessage());
        }

        var products =  ProductMapper.ProductDTOToProductCardViewModel(result.Data);
        return OperationResult<List<ProductCardViewModel>>.SuccessedResult(products);
    }
}
