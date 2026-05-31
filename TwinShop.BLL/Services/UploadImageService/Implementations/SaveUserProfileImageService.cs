using Microsoft.AspNetCore.Http;
using TwinShop.BLL.Services.UploadImageService.Interfaces;
using TwinShop.Shared.Custom_Exceptions;

namespace TwinShop.BLL.Services.UploadImageService.Implementations
{
    public class SaveUserProfileImageService : ISaveUserProfileImageService
    {
        private readonly ISavePhotoService _savePhotoService;

        public SaveUserProfileImageService(ISavePhotoService savePhotoService)
        {
            _savePhotoService = savePhotoService;
        }
        public async Task<string> UploadUserProfileImage(IFormFile image, int userId)
        {
            if (image == null)
                throw new FileValidationException("Please select an image for your profile"); 

            return await _savePhotoService.SaveUserProfileImageAsync(image, userId);
        }
    }
}
