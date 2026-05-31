using TwinShop.BLL.Services.Interfaces;
using TwinShop.DAL.Repositories.Interfaces;
using TwinShop.Shared.Custom_Exceptions;
using TwinShop.Shared.DTOS;
using TwinShop.Shared.ViewModels;

namespace TwinShop.BLL.Services.Implementations
{
    public class ProductValidationService : IProductValidationService
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IBrandRepository _brandRepository;
        public ProductValidationService(IProductRepository productRepository
                                        ,ICategoryRepository categoryRepository
                                        ,IBrandRepository  brandRepository)
        {
            _productRepository = productRepository;
            _brandRepository = brandRepository;
            _categoryRepository = categoryRepository;
        }
        public async Task ValidateProductAsync(ProductCardViewModel productViewModel)
        {
            if (!productViewModel.IsValid)
                throw new ValidationException(new List<string> { productViewModel.ErrorMessage });

            if (await _productRepository.ProductNameExistAsync(productViewModel.ProductName!))
                throw new BadRequestException(MessagesAndConsts.ProductNameAlreadyExist);

            if (!await _categoryRepository.CategoryIdExistsAsync(productViewModel.CategoryId!))
                throw new BadRequestException(MessagesAndConsts.CategoryNameNotExisted);

            if (!await _brandRepository.BrandIdExistsAsync(productViewModel.BrandId!))
                throw new BadRequestException(MessagesAndConsts.BrandNameNotExist);
        }
    }
}
