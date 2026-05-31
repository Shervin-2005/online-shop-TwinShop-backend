using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwinShop.BLL.Services.UploadImageService.Interfaces
{
    public interface ISaveUserProfileImageService
    {
        Task<string> UploadUserProfileImage(IFormFile image, int userId);
    }
}
