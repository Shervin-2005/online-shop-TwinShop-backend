using Twin_Shop__Web_API.DTOs.Auth;


namespace Twin_Shop__Web_API.Services.Interfaces
{
    public interface IAuthService
    {
        Task <string> RegisterAsync(RegisterDto dto);
        Task<bool> LoginAsync(LoginDto dto);
    }
}
