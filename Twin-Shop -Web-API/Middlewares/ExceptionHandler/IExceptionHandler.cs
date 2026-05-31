namespace Twin_Shop__Web_API.Middlewares.ExceptionHandler
{
    public interface IExceptionHandler
    {
        bool CanHandle(Exception exception);
        Task HandleAsync(HttpContext context, Exception exception);
    }
}
