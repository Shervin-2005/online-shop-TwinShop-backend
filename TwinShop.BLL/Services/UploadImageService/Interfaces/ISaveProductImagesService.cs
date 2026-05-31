using Microsoft.AspNetCore.Http;

namespace TwinShop.BLL.Services.UploadImageService.Interfaces
{
    public interface ISaveProductImagesService
    {
        Task UploadProductImages(List<IFormFile> images, int id, string productName);
    }
}
