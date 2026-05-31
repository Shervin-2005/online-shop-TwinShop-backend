using TwinShop.BLL.Services.Interfaces;
using TwinShop.DAL.Repositories.Interfaces;
using TwinShop.Shared.Custom_Exceptions;
using TwinShop.Shared.DTOS;
using TwinShop.Shared.Mappers;
using TwinShop.Shared.ViewModels.UserViewModels;

namespace TwinShop.BLL.Services.Implementations
{
    public class UserValidationService : IUserValidationService
    {
        private readonly IUserRepository _userRepository;

        public UserValidationService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<bool> VerifyPassword(string passwordHashUser, string passwordHashUserDto)
        {
            return (passwordHashUser == passwordHashUserDto);
        }
        public async Task<UserInfoViewModel> ValidateLoginWithPasswordAsync(LoginUserViewModel loginUserViewModel)
        {
            if (!loginUserViewModel.IsValid)
                throw new ValidationException(new List<string> { loginUserViewModel.ErrorMessage });

            var userDTO = await _userRepository.GetUserByPhoneAsync(loginUserViewModel.PhoneNumber!)!;
            if (userDTO == null) throw new UnauthorizedException();

            var isVerified = await VerifyPassword(userDTO.PasswordHash!, UserMapper.HashPassword(loginUserViewModel.Password!));
            if (!isVerified)
                throw new UnauthorizedException();

            return userDTO.UserDTOToUserInfoViewModel();
        }

        public async Task ValidateRegisterUserAsync(RegisterUserViewModel registerUserViewModel)
        {
            if (!registerUserViewModel.IsValid)
                throw new ValidationException(new List<string> { registerUserViewModel.ErrorMessage });

            if (await _userRepository.PhoneExistsAsync(registerUserViewModel.PhoneNumber!))
                throw new BadRequestException(MessagesAndConsts.PhoneNumberAlreadyExist);
        }

        public async Task ValidateUserInfoAsync(UserInfoViewModel userInfoViewModel, string phoneNumber)
        {
            if (!userInfoViewModel.IsValid)
                throw new ValidationException(new List<string> { userInfoViewModel.ErrorMessage });

            if (phoneNumber != userInfoViewModel.PhoneNumber)
            {
                if (await _userRepository.PhoneExistsAsync(userInfoViewModel.PhoneNumber!))
                    throw new BadRequestException(MessagesAndConsts.PhoneNumberAlreadyExist);
            }
        }
    }
}
