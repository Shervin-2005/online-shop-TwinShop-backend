using Microsoft.AspNetCore.Http;
using Twin_Shop__Web_API.DTOs.Brand;
using Twin_Shop__Web_API.Services.Interfaces;
using TwinShop.BLL.Services.Interfaces;
using TwinShop.BLL.Services.UploadImageService.Interfaces;
using TwinShop.DAL.Repositories.Interfaces;
using TwinShop.Shared.Custom_Exceptions;
using TwinShop.Shared.Mappers;
using TwinShop.Shared.ViewModels;
namespace Twin_Shop__Web_API.Services.Implementations
{
    public class BrandService : IBrandService
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IBrandValidationService _brandValidationService;
        private readonly ISaveBrandImageService _saveBrandImageService;

        public BrandService(IBrandRepository brandRepository,
                            IBrandValidationService brandValidationService,
                            ISaveBrandImageService saveBrandImageService)
        {
            _brandRepository = brandRepository;
            _brandValidationService = brandValidationService;
            _saveBrandImageService = saveBrandImageService;
        }

        public async Task<List<BrandViewModel>> GetAllBrandsAsync()
        {
            var brands = await _brandRepository.GetAllAsync();
            return brands.BrandDTOToBrandViewModel();
        }

        public async Task<BrandViewModel> GetBrandByIdAsync(int id)
        {
            var brand = await _brandRepository.GetByIdAsync(id);

            if (brand == null)
                throw new NotFoundException("Brand", id);

            return brand.BrandDTOToBrandViewModel();
        }

        public async Task<int> CreateBrandAsync(BrandViewModel brandViewModel)
        {
            await _brandValidationService.ValidateBrandAsync(brandViewModel);

            string imageUrl = await _saveBrandImageService.UploadBrandImage(brandViewModel.Image, brandViewModel.BrandName!);

            BrandDto brandDto = brandViewModel.BrandViewModelToBrandDTO();

            brandDto.MainImageUrl = imageUrl;

            var brandId = await _brandRepository.InsertAsync(brandDto);

            return brandId;
        }


        public async Task DeleteBrandAsync(int id)
        {
            if (!await _brandRepository.DeleteAsync(id))
                throw new NotFoundException("Brand", id);
        }

        public async Task UpdateBrandAsync(BrandViewModel brandViewModel, int id)
        {
            await _brandValidationService.ValidateBrandAsync(brandViewModel);

           string imageUrl = await _saveBrandImageService.UploadBrandImage(brandViewModel.Image, brandViewModel.BrandName!);

            BrandDto brandDto = brandViewModel.BrandViewModelToBrandDTO();

            brandDto.MainImageUrl = imageUrl;

             await _brandRepository.UpdateAsync(brandDto, id);
        }

        public async Task<List<BrandViewModel>> GetBrandsByCategoryNameAsync(string categoryName)
        {
            var brandDTOs = await _brandRepository.GetBrandsByCategoryNameAsync(categoryName);
            return brandDTOs.BrandDTOToBrandViewModel();
        }

        public async Task<List<BrandViewModel>> SearchBrandsAsync(string searchTerm)
        {
           if(string.IsNullOrWhiteSpace(searchTerm))
                return await GetAllBrandsAsync();

           var brandDTOs = await _brandRepository.SearchBrandsAsync(searchTerm);
            return brandDTOs.BrandDTOToBrandViewModel();
        }

    }

}