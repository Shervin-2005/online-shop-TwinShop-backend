
using Twin_Shop__Web_API.Entities;
using TwinShop.Shared;
using TwinShop.Shared.DTOS.Auth;
using TwinShop.Shared.ViewModels.UserViewModels;


namespace Twin_Shop__Web_API.Services.Interfaces
{
    public interface IAuthService
    {
        Task<OperationResult> RegisterAsync(RegisterUserViewModel registerUserViewModel);
        Task<OperationResult> EditUserInfoAsync(UserInfoViewModel userInfoViewModel, string phoneNumber);
        Task<OperationResult> LoginWithVerificationCodeAsync(UserViewModel userViewModel);
        Task<OperationResult<LoginUserViewModel>> LoginWithPasswordAsync(LoginUserViewModel LoginUserViewModel);
        Task<OperationResult<UserInfoViewModel>> GetByEmailAsync(string email);
        Task<OperationResult<UserInfoViewModel>> GetUserByPhoneAsync(string phoneNumber);
        Task<OperationResult> ChangePasswordAsync( ChangePasswordUserViewModel changePasswordUserViewModel,string phoneNumber);
    }
}
