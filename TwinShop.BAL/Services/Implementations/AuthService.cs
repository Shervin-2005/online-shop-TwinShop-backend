using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.Security.Cryptography;
using System.Text;
using Twin_Shop__Web_API.DTOs.Product;
using Twin_Shop__Web_API.Services.Interfaces;
using TwinShop.BLL;
using TwinShop.BLL.Services.Interfaces;
using TwinShop.DAL.Repositories.Implementations;
using TwinShop.DAL.Repositories.Interfaces;
using TwinShop.Shared;
using TwinShop.Shared.DTOS;
using TwinShop.Shared.DTOS.Auth;
using TwinShop.Shared.ErrorHandling;
using TwinShop.Shared.Mappers;
using TwinShop.Shared.ViewModels.UserViewModels;

namespace Twin_Shop__Web_API.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IErrorService _errorService;

        public AuthService(IUserRepository userRepository, IErrorService errorService)
        {
            _userRepository = userRepository;
            _errorService = errorService;
        }

        public async Task<OperationResult> RegisterAsync(RegisterUserViewModel registerUserViewModel)
        {
            try
            {
                if (!registerUserViewModel.IsValid)
                {
                    return OperationResult.Failed(registerUserViewModel.ErrorMessage);
                }
                UserDto userDto = UserMapper.RegisterViewToUserDTO(registerUserViewModel);
                var isPhoneExist = await _userRepository.PhoneExistsAsync(userDto.PhoneNumber!);

                if (isPhoneExist.Success)
                {
                    return OperationResult.Failed(MessagesAndConsts.PhoneNumberAlreadyExist);
                }
                var isUserAdded = await _userRepository.AddUserAsync(userDto);

                if (!isUserAdded.Success)
                {
                    return OperationResult.Failed(MessagesAndConsts.FailedSignUp1);
                }

                return OperationResult.SuccessedResult(true, MessagesAndConsts.SuccessSignUp1);
            }
            catch(Exception ex)
            {
                var error = ex!.ExceptionToErrorDTO("BLL-AuthService");
                var result = await _errorService.LogErrorAsync(error);
                return OperationResult.Failed(result.Message!.ErrorMessage());
            }
        }

        public async Task<OperationResult> EditUserInfoAsync(UserInfoViewModel userInfoViewModel, string phoneNumber)
        {
            if (!userInfoViewModel.IsValid)
                return OperationResult.Failed(userInfoViewModel.ErrorMessage);
            if (!userInfoViewModel.ProfileImage!.Contains(MessagesAndConsts.Url))
            {
                var savePhoto = new SavePhoto();
                var savingPhoto = await savePhoto.SaveAsync(userInfoViewModel.ProfileImage!);
                if (!savingPhoto.Success)
                {
                    var error = savingPhoto.Exception!.ExceptionToErrorDTO(savingPhoto.Message!);
                    var result = await _errorService.LogErrorAsync(error);
                    return OperationResult.Failed(result.Message!.ErrorMessage());
                }

                userInfoViewModel.ProfileImage = savingPhoto.Message;
            }

            if (phoneNumber != userInfoViewModel.PhoneNumber)
            {
                var isPhoneExist = await _userRepository
                                         .PhoneExistsAsync(userInfoViewModel.PhoneNumber!);
                if (isPhoneExist.Success)
                {
                    return OperationResult.Failed(MessagesAndConsts.PhoneNumberAlreadyExist);
                }
            }
                    UserDto userDto = UserMapper.UserInfoViewToUserDTO(userInfoViewModel);
                    var updateUser = await _userRepository.UpdateUserAsync(userDto);
                    if (!updateUser.Success)
                    {
                        var error = updateUser.Exception!.ExceptionToErrorDTO(updateUser.Message!);
                        var result2 = await _errorService.LogErrorAsync(error);
                        return OperationResult.Failed(result2.Message!.ErrorMessage());
                    }
                
                return OperationResult.SuccessedResult(true, MessagesAndConsts.update);
            
        }
        public async Task<OperationResult<LoginUserViewModel>> LoginWithPasswordAsync(LoginUserViewModel loginUserViewModel)
        {
            try
            {
                var user = await _userRepository.GetUserByPhoneAsync(loginUserViewModel.PhoneNumber!);

                if (!user!.Success)
                {
                    return OperationResult<LoginUserViewModel>.Failed(MessagesAndConsts.userNotLoginWithThisPhoneNumber);
                }

                loginUserViewModel.Id=user.Data.Id;

                var isVerified = await _userRepository
                    .VerifyPassword(user.Data.PasswordHash!, UserMapper.HashPassword(loginUserViewModel.Password!));

                if (!isVerified.Success)
                {
                    return OperationResult<LoginUserViewModel>.Failed(MessagesAndConsts.FailedLogin);
                }
                return OperationResult<LoginUserViewModel>.SuccessedResult(loginUserViewModel, MessagesAndConsts.LoginText);
              
            }
            catch(Exception ex)
            {
                var error = ex!.ExceptionToErrorDTO("BLL-AuthService");
                var result = await _errorService.LogErrorAsync(error);
                return OperationResult<LoginUserViewModel>.Failed(result.Message!);
            }
    }

        public async Task<OperationResult> LoginWithVerificationCodeAsync(UserViewModel userView)
        {
            var user = await _userRepository.GetUserByPhoneAsync(userView.PhoneNumber!);

            if (!user.Success)
            {
                return OperationResult.Failed(MessagesAndConsts.userNotLoginWithThisPhoneNumber);
            }
            //باید sms بیاد
            var isVerified = await _userRepository
                .VerifyPassword(user.Data.PasswordHash!, UserMapper.HashPassword(userView.Password!));

            if (!isVerified.Success)
            {
                if (!isVerified.Success)
                {
                    var error = isVerified.Exception!.ExceptionToErrorDTO(isVerified.Message!);
                    var result = await _errorService.LogErrorAsync(error);
                    return OperationResult.Failed(result.Message!.ErrorMessage());
                }
                return OperationResult.Failed(MessagesAndConsts.userNotLoginWithThisPhoneNumber);
            }
            return OperationResult.SuccessedResult();
        }
       

     

        public async Task<OperationResult<UserInfoViewModel>> GetByEmailAsync(string email)
        {
            var result = await _userRepository.GetByEmailAsync(email);
            if (!result!.Success)
            {
                if (!result.Success)
                {
                    var error = result.Exception!.ExceptionToErrorDTO(result.Message!);
                    var result1 = await _errorService.LogErrorAsync(error);
                    return OperationResult<UserInfoViewModel>.Failed(result1.Message!.ErrorMessage());
                }
                return OperationResult<UserInfoViewModel>.Failed();
            }
            return OperationResult<UserInfoViewModel>.SuccessedResult(result.Data.UserDTOToUserInfoViewModel());

        }

        public async Task<OperationResult<UserInfoViewModel>> GetUserByPhoneAsync(string phoneNumber)
        {
            var result = await _userRepository.GetUserByPhoneAsync(phoneNumber);         
                if (!result!.Success)
                {
                    var error = result.Exception!.ExceptionToErrorDTO(result.Message!);
                    var errorLog = await _errorService.LogErrorAsync(error);
                    return OperationResult<UserInfoViewModel>.Failed(errorLog.Message!.ErrorMessage());
                }
            return OperationResult<UserInfoViewModel>.SuccessedResult(result.Data.UserDTOToUserInfoViewModel());
        }

        public async Task<OperationResult> ChangePasswordAsync(ChangePasswordUserViewModel changePasswordUserViewModel, string phoneNumber)
        {
            var userResult = await _userRepository.GetUserByPhoneAsync(phoneNumber);
            if (!userResult!.Success)
            {
                var error = userResult.Exception!.ExceptionToErrorDTO(userResult.Message!);
                var errorLog = await _errorService.LogErrorAsync(error);
                return OperationResult.Failed(errorLog.Message!.ErrorMessage());
            }

            var user = userResult.Data;

           if(user.PasswordHash != UserMapper.HashPassword(changePasswordUserViewModel.CurrentPassword!))
            {
                return OperationResult.Failed(MessagesAndConsts.WrongCurrentPassword);
            }

            user.PasswordHash = UserMapper.HashPassword(changePasswordUserViewModel.Password!);
    
            var updateResult = await _userRepository.UpdateUserPassword(user);
            if (!updateResult.Success)
            {
                var error = updateResult.Exception!.ExceptionToErrorDTO(updateResult.Message!);
                var errorLog = await _errorService.LogErrorAsync(error);
                return OperationResult.Failed(errorLog.Message!.ErrorMessage());
            }
            return OperationResult.SuccessedResult(true,MessagesAndConsts.PasswordChangedSuccess);
        }
    }
}
