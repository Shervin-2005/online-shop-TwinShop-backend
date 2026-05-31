using TwinShop.Shared.Custom_Exceptions;
using TwinShop.Shared.DTOs;

namespace Twin_Shop__Web_API.Middlewares.ExceptionHandler
{
    public class FileValidationExceptionHandler : IExceptionHandler
    {
        public bool CanHandle(Exception exception) =>
            exception is FileValidationException;

        public async Task HandleAsync(HttpContext context, Exception exception)
        {
            var ex = (FileValidationException)exception;
            context.Response.StatusCode = ex.StatusCode;
            await context.Response.WriteAsJsonAsync(new ErrorResponse
            {
                StatusCode = ex.StatusCode,
                Message = ex.Message,
            });
        }
    }
}
