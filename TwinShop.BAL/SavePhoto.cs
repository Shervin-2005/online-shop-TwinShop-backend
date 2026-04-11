using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwinShop.Shared;

namespace TwinShop.BLL
{
    public class SavePhoto
    {
        private const string accessKey = "af354ed6-dcae-422c-88a2-65f5f35f3526";
        private const string secretKey = "12bcccbb981f573ae80ad702df788ded4d9e4bd5ab20967bc4ff456ceb56b47f";
        private const string bucketName = "shams1384";
        private const string serviceURL = "https://shams1384.s3.ir-thr-at1.arvanstorage.ir";
        private readonly IAmazonS3 _s3Client;
        public SavePhoto()
        {
            var config = new AmazonS3Config
            {
                ServiceURL = serviceURL,
                ForcePathStyle = true, 
                AuthenticationRegion = "ir-thr-at1"
            };

            var credentials = new BasicAWSCredentials(accessKey, secretKey);
            _s3Client = new AmazonS3Client(credentials, config);
        }

        public void Dispose()
        {
            _s3Client.Dispose();
        }

        public async Task<OperationResult> SaveAsync(string filePath)
        {
            try
            {
                string objectKey = Path.GetFileName(filePath).Replace(" ", "_");

                var putRequest = new PutObjectRequest
                {
                    BucketName = bucketName,
                    Key = objectKey,
                    FilePath = filePath,
                    CannedACL = S3CannedACL.PublicRead // فایل Public بشه
                };

                await _s3Client.PutObjectAsync(putRequest);

                string fileUrl = $"{serviceURL}/{bucketName}/{objectKey}";
                return OperationResult.SuccessedResult(true, fileUrl);
            }
            catch (Exception ex)
            {
                return OperationResult.Failed(GetType().Name, ex);
            }
        }
    }
}
