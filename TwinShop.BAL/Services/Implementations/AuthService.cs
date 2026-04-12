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
using TwinShop.Shared.ViewModels;

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

        public async Task<OperationResult> RegisterAsync(UserViewModel userView)
        {
            try
            {
                if (!userView.IsValid)
                {
                    return OperationResult.Failed(userView.ErrorMessage);
                }
                UserDto userDto = UserMapper.ToUserDTO(userView);
                userDto.PasswordHash = HashPassword(userDto.PasswordHash!);
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

        public async Task<OperationResult> EditUserInfoAsync(UserViewModel userView, string phoneNumber)
        {
            if (!userView.IsValid)
                return OperationResult.Failed(userView.ErrorMessage);
            if (!userView.ProfileImage!.Contains(MessagesAndConsts.Url))
            {
                var savePhoto = new SavePhoto();
                var savingPhoto = await savePhoto.SaveAsync(userView.ProfileImage!);
                if (!savingPhoto.Success)
                {
                    var error = savingPhoto.Exception!.ExceptionToErrorDTO(savingPhoto.Message!);
                    var result = await _errorService.LogErrorAsync(error);
                    return OperationResult.Failed(result.Message!.ErrorMessage());
                }

                userView.ProfileImage = savingPhoto.Message;
            }

            if (phoneNumber != userView.PhoneNumber)
            {
                var isPhoneExist = await _userRepository
                                         .PhoneExistsAsync(userView.PhoneNumber!);
                if (isPhoneExist.Success)
                {
                    return OperationResult.Failed(MessagesAndConsts.PhoneNumberAlreadyExist);
                }
                userView.PhoneNumber = phoneNumber;
            }
                    UserDto userDto = UserMapper.ToUserDTO(userView);
                    var updateUser = await _userRepository.UpdateUserAsync(userDto);
                    if (!updateUser.Success)
                    {
                        var error = updateUser.Exception!.ExceptionToErrorDTO(updateUser.Message!);
                        var result2 = await _errorService.LogErrorAsync(error);
                        return OperationResult.Failed(result2.Message!.ErrorMessage());
                    }
                
                return OperationResult.SuccessedResult(true, MessagesAndConsts.update);
            
        }
        public async Task<OperationResult<UserViewModel>> LoginWithPasswordAsync(UserViewModel userView)
        {
            try
            {
                var user = await _userRepository.GetByPhoneAsync(userView.PhoneNumber!);

                if (!user!.Success)
                {
                    return OperationResult<UserViewModel>.Failed(MessagesAndConsts.userNotLoginWithThisPhoneNumber);
                }
                userView.Id=user.Data.Id;
                var isVerified = await _userRepository
                    .VerifyPassword(user.Data.PasswordHash!, HashPassword(userView.Password!));

                if (!isVerified.Success)
                {
                    return OperationResult<UserViewModel>.Failed(MessagesAndConsts.FailedLogin);
                }
                return OperationResult<UserViewModel>.SuccessedResult(userView,MessagesAndConsts.LoginText);
              
            }
            catch(Exception ex)
            {
                var error = ex!.ExceptionToErrorDTO("BLL-AuthService");
                var result = await _errorService.LogErrorAsync(error);
                return OperationResult<UserViewModel>.Failed(result.Message!);
            }
    }

        public async Task<OperationResult> LoginWithVerificationCodeAsync(UserViewModel userView)
        {
            var user = await _userRepository.GetByPhoneAsync(userView.PhoneNumber!);

            if (!user.Success)
            {
                return OperationResult.Failed(MessagesAndConsts.userNotLoginWithThisPhoneNumber);
            }
            //باید sms بیاد
            var isVerified = await _userRepository
                .VerifyPassword(user.Data.PasswordHash!, HashPassword(userView.Password!));

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
        private string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }

     

        public async Task<OperationResult<UserViewModel>> GetByEmailAsync(string email)
        {
            var result = await _userRepository.GetByEmailAsync(email);
            if (!result!.Success)
            {
                if (!result.Success)
                {
                    var error = result.Exception!.ExceptionToErrorDTO(result.Message!);
                    var result1 = await _errorService.LogErrorAsync(error);
                    return OperationResult<UserViewModel>.Failed(result1.Message!.ErrorMessage());
                }
                return OperationResult<UserViewModel>.Failed();
            }
            return OperationResult<UserViewModel>.SuccessedResult(result.Data.ToUserViewModel());

        }

        public async Task<OperationResult<UserViewModel>> GetByPhoneAsync(string phoneNumber)
        {
            var result = await _userRepository.GetByPhoneAsync(phoneNumber);         
                if (!result!.Success)
                {
                    var error = result.Exception!.ExceptionToErrorDTO(result.Message!);
                    var result1 = await _errorService.LogErrorAsync(error);
                    return OperationResult<UserViewModel>.Failed(result1.Message!.ErrorMessage());
                }
            return OperationResult<UserViewModel>.SuccessedResult(result.Data.ToUserViewModel());
        }

       
    }
}
