using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using TwinShop.BLL.Services.UploadImageService.Interfaces;
using TwinShop.BLL.Services.UploadImageService.Options;

public class SavePhotoService : ISavePhotoService
{
    private readonly IAmazonS3 _s3Client;
    private readonly IFileValidatorService _fileValidatorService;
    private readonly ArvanStorageOptions _options;
    private static class Folders
    {
        public const string CategoryImage = "categories/{0}/image/";
        public const string BrandImage = "brands/{0}/image/";
        public const string ProductImages = "products/{0}/images/";
        public const string UserProfileImage = "users/{0}/ProfileImage/";
    }

    public SavePhotoService(IAmazonS3 s3Client, IFileValidatorService fileValidatorService , IOptions<ArvanStorageOptions> options)
    {
      _s3Client = s3Client;
      _fileValidatorService = fileValidatorService;
      _options = options.Value;
    }

    public async Task<string> UploadAsync(IFormFile file, string folder)
    {
     
        _fileValidatorService.Validator(file);

        var fileName = _fileValidatorService.GenerateUniqueFileName(file);

        string objectKey = $"{folder}{fileName}";

        using var stream = file.OpenReadStream();

        var putRequest = new PutObjectRequest
        {
            BucketName = _options.BucketName,
            Key = objectKey,
            InputStream = stream,
            ContentType = file.ContentType,
            CannedACL = S3CannedACL.PublicRead
        };
        await _s3Client.PutObjectAsync(putRequest);
      
        return $"{_options.ServiceURL}/{_options.BucketName}/{objectKey}";
    }
    public Task<string> SaveCategoryImageAsync(IFormFile file, string categoryName)
            => UploadAsync(file, string.Format(Folders.CategoryImage, _fileValidatorService.SanitizeName(categoryName)));

    public Task<string> SaveBrandImageAsync(IFormFile file, string brandName)
        => UploadAsync(file, string.Format(Folders.BrandImage, _fileValidatorService.SanitizeName(brandName)));

    public Task<string> SaveProductImageAsync(IFormFile file, string productName)
        => UploadAsync(file, string.Format(Folders.ProductImages, _fileValidatorService.SanitizeName(productName)));

    public Task<string> SaveUserProfileImageAsync(IFormFile file, int userId)
        => UploadAsync(file, string.Format(Folders.UserProfileImage, userId));
}

