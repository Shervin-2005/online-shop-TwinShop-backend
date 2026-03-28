
using Twin_Shop__Web_API.Entities;
using TwinShop.Shared;
using TwinShop.Shared.DTOS.Auth;
using TwinShop.Shared.ViewModels;


namespace Twin_Shop__Web_API.Services.Interfaces
{
    public interface IAuthService
    {
        Task<OperationResult> RegisterAsync(UserViewModel userView);
        Task<OperationResult> LoginWithVerificationCodeAsync(UserViewModel userView); 
        Task<OperationResult> LoginWithPasswordAsync(UserViewModel userView);
        Task<OperationResult<UserDto>> GetByEmailAsync(string email);
        Task<OperationResult<UserDto>> GetByPhoneAsync(string phoneNumber);
    }
}
