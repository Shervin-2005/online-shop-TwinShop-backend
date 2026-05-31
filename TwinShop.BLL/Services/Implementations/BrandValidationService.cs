using TwinShop.BLL.Services.Interfaces;
using TwinShop.DAL.Repositories.Interfaces;
using TwinShop.Shared.Custom_Exceptions;
using TwinShop.Shared.DTOS;
using TwinShop.Shared.ViewModels;

namespace TwinShop.BLL.Services.Implementations
{
    public class BrandValidationService : IBrandValidationService
    {
        private readonly IBrandRepository _brandRepository;

        public BrandValidationService(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public async Task ValidateBrandAsync(BrandViewModel brandViewModel)
        {
            if (!brandViewModel.IsValid)
                throw new ValidationException(new List<string> { brandViewModel.ErrorMessage });

            if (await _brandRepository.BrandNameExistsAsync(brandViewModel.BrandName!))
                throw new BadRequestException(MessagesAndConsts.BrandNameAlreadyExist);
                
            // also write validation for categories
        }
    }
}
