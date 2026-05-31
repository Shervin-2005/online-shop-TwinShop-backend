using Amazon.S3;
using Microsoft.Identity.Client.Extensions.Msal;
using TwinShop.Shared.DTOs;

namespace Twin_Shop__Web_API.Middlewares.ExceptionHandler
{
    public class AmazonS3ExceptionHandler : IExceptionHandler
    {
        public bool CanHandle(Exception exception) => exception is AmazonS3Exception;

        public async Task HandleAsync(HttpContext context, Exception exception)
        {
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            await context.Response.WriteAsJsonAsync(new ErrorResponse
            {
                StatusCode = StatusCodes.Status500InternalServerError,
                Message = "Failed to upload file to storage.Please try again later.",
            });
        }
    }
}
