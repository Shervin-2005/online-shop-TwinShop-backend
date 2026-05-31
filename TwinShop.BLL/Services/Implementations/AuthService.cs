using Microsoft.AspNetCore.Http;
using Twin_Shop__Web_API.Services.Interfaces;
using TwinShop.BLL.Services.Interfaces;
using TwinShop.BLL.Services.UploadImageService.Interfaces;
using TwinShop.DAL.Repositories.Interfaces;
using TwinShop.Shared.Custom_Exceptions;
using TwinShop.Shared.DTOS.Auth;
using TwinShop.Shared.Mappers;
using TwinShop.Shared.ViewModels.UserViewModels;

namespace Twin_Shop__Web_API.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserValidationService _userValidationService;
        private readonly ISaveUserProfileImageService _saveUserProfileImageService;

        public AuthService(IUserRepository userRepository,
                           IUserValidationService userValidationService,
                           ISaveUserProfileImageService saveUserProfileImageService)
        {
            _userRepository = userRepository;
            _userValidationService = userValidationService;
            _saveUserProfileImageService = saveUserProfileImageService;
        }

        public async Task<int> RegisterAsync(RegisterUserViewModel registerUserViewModel)
        {
            await _userValidationService.ValidateRegisterUserAsync(registerUserViewModel);

            UserDto userDto = UserMapper.RegisterViewToUserDTO(registerUserViewModel);

            var userId = await _userRepository.AddUserAsync(userDto);

            return userId;
        }

        public async Task EditUserInfoAsync(UserInfoViewModel userInfoViewModel, string phoneNumber, int Userid)
        {
            await _userValidationService.ValidateUserInfoAsync(userInfoViewModel, phoneNumber);

            string imageUrl = await _saveUserProfileImageService.UploadUserProfileImage(userInfoViewModel.Image, Userid);   

            UserDto userDto = UserMapper.UserInfoViewToUserDTO(userInfoViewModel);

            userDto.ProfileImage = imageUrl;

            await _userRepository.UpdateUserAsync(userDto, Userid);
        }
        public async Task<UserInfoViewModel> LoginWithPasswordAsync(LoginUserViewModel loginUserViewModel)
        {
            var user =  await _userValidationService.ValidateLoginWithPasswordAsync(loginUserViewModel);
            return user;
        }

        public async Task ChangePasswordAsync(ChangePasswordUserViewModel changePasswordUserViewModel, string phoneNumber)
        {
            var user = await _userRepository.GetUserByPhoneAsync(phoneNumber);

            if (user == null) throw new UnauthorizedException();

            if (user.PasswordHash != UserMapper.HashPassword(changePasswordUserViewModel.CurrentPassword!))
                throw new UnauthorizedException();

            user.PasswordHash = UserMapper.HashPassword(changePasswordUserViewModel.Password!);

            await _userRepository.UpdateUserPassword(user);
        }
    }
}
