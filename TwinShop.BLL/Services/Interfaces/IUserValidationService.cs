using TwinShop.Shared.ViewModels.UserViewModels;

namespace TwinShop.BLL.Services.Interfaces
{
    public interface IUserValidationService
    {
        Task ValidateRegisterUserAsync(RegisterUserViewModel registerUserViewModel);
        Task ValidateUserInfoAsync(UserInfoViewModel userInfoViewModel, string phoneNumber);
        Task<UserInfoViewModel> ValidateLoginWithPasswordAsync(LoginUserViewModel loginUserViewModel);
    }
}
