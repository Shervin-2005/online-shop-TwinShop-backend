using TwinShop.Shared.DTOs;

namespace Twin_Shop__Web_API.Middlewares.ExceptionHandler
{
    public class DefaultExceptionHandler : IExceptionHandler
    {
        private readonly IWebHostEnvironment _env;
        public DefaultExceptionHandler(IWebHostEnvironment env) => _env = env;

        public bool CanHandle(Exception exception) => true; //fallback

        public async Task HandleAsync(HttpContext context , Exception exception)
        {
            context.Response.StatusCode = 500;
            await context.Response.WriteAsJsonAsync(new ErrorResponse
            {
                StatusCode = 500,
                Message = "An unexpected error occurred.",
                Details = _env.IsDevelopment() ? exception.ToString() : null
            });
        }
    }
}
