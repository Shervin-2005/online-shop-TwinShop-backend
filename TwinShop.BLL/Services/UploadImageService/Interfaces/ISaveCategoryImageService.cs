using Microsoft.AspNetCore.Http;

namespace TwinShop.BLL.Services.UploadImageService.Interfaces
{
    public interface ISaveCategoryImageService
    {
        Task<string> UploadCategoryImage(IFormFile image, string categoryName);
    }
}
