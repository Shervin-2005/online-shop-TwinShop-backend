using TwinShop.Shared.Custom_Exceptions;
using TwinShop.Shared.DTOs;

namespace Twin_Shop__Web_API.Middlewares.ExceptionHandler
{
    public class DatabaseExceptionHandler : IExceptionHandler
    {
        private readonly IWebHostEnvironment _env;
        public DatabaseExceptionHandler(IWebHostEnvironment env) => _env = env;

        public bool CanHandle(Exception exception) => exception is DatabaseException;

        public async Task HandleAsync(HttpContext context, Exception exception)
        {
            var ex = (DatabaseException)exception;
            context.Response.StatusCode = ex.StatusCode;
            await context.Response.WriteAsJsonAsync(new ErrorResponse
            {
                StatusCode = ex.StatusCode,
                Message = "A database error occurred.",
                Details = _env.IsDevelopment() ? exception.InnerException?.ToString() : null
            });
        }
    }
}
