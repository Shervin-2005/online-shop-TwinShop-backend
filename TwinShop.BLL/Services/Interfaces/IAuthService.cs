using Microsoft.AspNetCore.Http;
using TwinShop.Shared.ViewModels.UserViewModels;

namespace Twin_Shop__Web_API.Services.Interfaces
{
    public interface IAuthService
    {
        Task<int> RegisterAsync(RegisterUserViewModel registerUserViewModel);
        Task EditUserInfoAsync(UserInfoViewModel userInfoViewModel, string phoneNumber, int Userid);
        Task<UserInfoViewModel> LoginWithPasswordAsync(LoginUserViewModel loginUserViewModel);
        Task ChangePasswordAsync(ChangePasswordUserViewModel changePasswordUserViewModel, string phoneNumber);
    }
}
