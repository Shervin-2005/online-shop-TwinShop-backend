using Twin_Shop__Web_API.Middlewares.ExceptionHandler;

namespace Twin_Shop__Web_API.Middlewares
{
    public class GlobalExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionHandlerMiddleware> _logger;
        private readonly IEnumerable<IExceptionHandler> _handlers;

        public GlobalExceptionHandlerMiddleware(RequestDelegate next,ILogger<GlobalExceptionHandlerMiddleware>logger, IEnumerable<IExceptionHandler> handlers)
        {
            _next = next;
            _logger = logger;
            _handlers = handlers;
        }
        public async Task InvokeAsync (HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled exception: {Message}" ,ex.Message);
                context.Response.ContentType = "application/json";

                var handler = _handlers.FirstOrDefault(h => h.CanHandle(ex));
                await handler!.HandleAsync(context, ex);
            }
        }
    }
}
