using Microsoft.AspNetCore.Http;

namespace TwinShop.BLL.Services.UploadImageService.Interfaces
{
    public interface ISaveBrandImageService
    {
        Task<string> UploadBrandImage(IFormFile image, string brandName);
    }
}
