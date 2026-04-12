
using Twin_Shop__Web_API.Entities;
using TwinShop.Shared;
using TwinShop.Shared.DTOS.Auth;
using TwinShop.Shared.ViewModels;


namespace Twin_Shop__Web_API.Services.Interfaces
{
    public interface IAuthService
    {
        Task<OperationResult> RegisterAsync(UserViewModel userView);
        Task<OperationResult> EditUserInfoAsync(UserViewModel userView, string phoneNumber);
        Task<OperationResult> LoginWithVerificationCodeAsync(UserViewModel userView);
        Task<OperationResult<LoginUserViewModel>> LoginWithPasswordAsync(LoginUserViewModel userView);
        Task<OperationResult<UserViewModel>> GetByEmailAsync(string email);
        Task<OperationResult<UserViewModel>> GetByPhoneAsync(string phoneNumber);
    }
}
