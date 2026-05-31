using Microsoft.AspNetCore.Http;
using TwinShop.BLL.Services.UploadImageService.Interfaces;
using TwinShop.Shared.Custom_Exceptions;

namespace TwinShop.BLL.Services.UploadImageService.Implementations
{
    public class SaveCategoryImageService : ISaveCategoryImageService
    {
        private readonly ISavePhotoService _savePhotoService;
        public SaveCategoryImageService(ISavePhotoService savePhotoService)
        {
            _savePhotoService = savePhotoService;
        }

        public async Task<string> UploadCategoryImage(IFormFile image, string categoryName)
        {
            if (image == null)
                throw new FileValidationException("Please select an image");

            return await _savePhotoService.SaveCategoryImageAsync(image, categoryName);
        }
    }
}
