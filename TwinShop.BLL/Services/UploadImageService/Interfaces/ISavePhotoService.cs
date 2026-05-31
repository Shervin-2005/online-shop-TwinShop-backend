using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TwinShop.BLL.Services.UploadImageService.Interfaces
{
    public interface ISavePhotoService
    {
        Task<string> UploadAsync(IFormFile file, string folder);
        Task<string> SaveCategoryImageAsync(IFormFile file, string categoryName);
        Task<string> SaveBrandImageAsync(IFormFile file, string brandName);
        Task<string> SaveProductImageAsync(IFormFile file, string productName);
        Task<string> SaveUserProfileImageAsync(IFormFile file, int userId);
    }
}
