using Microsoft.AspNetCore.Http;
using System.Text.RegularExpressions;
using TwinShop.BLL.Services.UploadImageService.Interfaces;
using TwinShop.Shared.Custom_Exceptions;

namespace TwinShop.BLL.Services.UploadImageService.Implementations
{
    public class FileValidatorService : IFileValidatorService
    {
        private readonly string[] _allowedExtensions = { ".jpg", ".jpeg", ".png", ".webp", ".gif" };
        private readonly long _maxFileSize = 5 * 1024 * 1024; // 5MB in bytes

        public void Validator(IFormFile file)
        {

            if (file == null || file.Length == 0)
                throw new FileValidationException("Please choose a file");

            if (file.Length == 0)
                throw new FileValidationException("Please choose a file");

            var extension = Path.GetExtension(file.FileName).ToLower();

            if (!_allowedExtensions.Contains(extension))
                throw new FileValidationException($"Format {extension} is not valid");

            if (file.Length > _maxFileSize)
                throw new FileValidationException("File must be less than 5MB");
        }
        public string GenerateUniqueFileName(IFormFile file)
        {
            var extension = Path.GetExtension(file.FileName).ToLower();
            return $"{Guid.NewGuid()}{extension}";
        }
        public string SanitizeName(string name)
        {
            var sanitized = Regex.Replace(name, @"[^\w\-]", "_");
            sanitized = Regex.Replace(sanitized, @"_+", "_");

            return sanitized.Trim('_');
        }
    }
}
