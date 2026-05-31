using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace TwinShop.BLL.Services.UploadImageService.Interfaces
{
    public interface IFileValidatorService
    {
        void Validator(IFormFile file);
        string GenerateUniqueFileName(IFormFile file);
        string SanitizeName(string name);
    }
}
