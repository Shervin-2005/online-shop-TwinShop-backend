using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;
using TwinShop.Shared;

public class SavePhoto : IDisposable
{
    private const string AccessKey = "af354ed6-dcae-422c-88a2-65f5f35f3526";
    private const string SecretKey = "12bcccbb981f573ae80ad702df788ded4d9e4bd5ab20967bc4ff456ceb56b47f";
    private const string BucketName = "shams1384";
    private const string ServiceURL = "https://shams1384.s3.ir-thr-at1.arvanstorage.ir";

    private readonly IAmazonS3 _s3Client;

    private static class Folders
    {
        public const string ProductMainImage = "products/{0}/main-image/";
        public const string CategoryMainImage = "categories/{0}/main-image/";
        public const string BrandMainImage = "brands/{0}/main-image/";
        public const string ProductSideImages = "products/{0}/gallery/";
        public const string UserProfileImage = "users/{0}/ProfileImage/";
    }

    public SavePhoto()
    {
        var config = new AmazonS3Config
        {
            ServiceURL = ServiceURL,
            ForcePathStyle = true,
            AuthenticationRegion = "ir-thr-at1"
        };

        var credentials = new BasicAWSCredentials(AccessKey, SecretKey);
        _s3Client = new AmazonS3Client(credentials, config);
    }

    private async Task<OperationResult> UploadAsync(string filePath, string folder)
    {
        try
        {
            string fileName = Path.GetFileName(filePath).Replace(" ", "_");
            string objectKey = $"{folder}{fileName}";

            var putRequest = new PutObjectRequest
            {
                BucketName = BucketName,
                Key = objectKey,
                FilePath = filePath,
                CannedACL = S3CannedACL.PublicRead
            };

            await _s3Client.PutObjectAsync(putRequest);

            string fileUrl = $"{ServiceURL}/{BucketName}/{objectKey}";
            return OperationResult.SuccessedResult(true, fileUrl);
        }
        catch (Exception ex)
        {
            return OperationResult.Failed(GetType().Name, ex);
        }
    }


    public Task<OperationResult> SaveProductMainAsync(string filePath , string productName)
        => UploadAsync(filePath, string.Format(Folders.ProductMainImage, productName));
    public Task<OperationResult> SaveCategoryMainAsync(string filePath, string categoryName)
       => UploadAsync(filePath, string.Format(Folders.CategoryMainImage, categoryName));

    public Task<OperationResult> SaveBrandMainAsync(string filePath, string brandName)
     => UploadAsync(filePath, string.Format(Folders.BrandMainImage, brandName));

    public Task<OperationResult> SaveProductGalleryAsync(string filePath, int productId)
        => UploadAsync(filePath, string.Format(Folders.ProductSideImages, productId));

    public Task<OperationResult> SaveUserProfileImageAsync(string filePath, int userId)
        => UploadAsync(filePath, string.Format(Folders.UserProfileImage, userId));


    public void Dispose() => _s3Client.Dispose();
}

