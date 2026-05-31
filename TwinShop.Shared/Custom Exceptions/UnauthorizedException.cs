namespace TwinShop.Shared.Custom_Exceptions
{
    public class UnauthorizedException : AppException
    {
        public UnauthorizedException(string message)
            : base(message, 401) { }

        public UnauthorizedException()
            :base("Authentication failed.Invalid credentials", 401) { }
    }
}
