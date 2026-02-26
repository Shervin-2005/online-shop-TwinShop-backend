using Twin_Shop__Web_API.DTOs.Auth;
using Twin_Shop__Web_API.Entities;
using TwinShop.Shared.DTOS.Auth;


namespace Twin_Shop__Web_API.Services.Interfaces
{
    public interface IAuthService
    {
        Task <string> RegisterAsync(RegisterDto dto);
        Task<bool> LoginAsync(LoginDto dto);
        Task<UserDto> GetByEmailAsync(string email);
        Task<UserDto> GetByPhoneAsync(string phoneNumber);
    }
}
