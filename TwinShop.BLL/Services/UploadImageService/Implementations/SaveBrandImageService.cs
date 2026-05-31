using Microsoft.AspNetCore.Http;
using TwinShop.BLL.Services.UploadImageService.Interfaces;
using TwinShop.Shared.Custom_Exceptions;

namespace TwinShop.BLL.Services.UploadImageService.Implementations
{
    public class SaveBrandImageService : ISaveBrandImageService
    {
        private readonly ISavePhotoService _savePhotoService;
        public SaveBrandImageService(ISavePhotoService savePhotoService)
        {
            _savePhotoService = savePhotoService;
        }

    
       public async Task<string> UploadBrandImage(IFormFile image, string brandName)
       {
            if (image == null)
                throw new FileValidationException("Please select an iamge");

           return await _savePhotoService.SaveBrandImageAsync(image, brandName);
       }
    }
}
