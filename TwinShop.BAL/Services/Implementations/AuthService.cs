using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Twin_Shop__Web_API.Services.Interfaces;
using TwinShop.BLL.Services.Interfaces;
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
        private readonly IVerificationCodeService _verificationCodeService;

        public AuthService(IUserRepository userRepository, IErrorService errorService, IVerificationCodeService verificationCodeService)
        {
            _userRepository = userRepository;
            _errorService = errorService;
            _verificationCodeService = verificationCodeService;
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
                userDto.PasswordHash = HashPassword(userDto.PasswordHash);
                var isPhoneExist = await _userRepository.PhoneExistsAsync(userDto.PhoneNumber);

                if (isPhoneExist.Success)
                {
                    return OperationResult.Failed(Messages.PhoneNumberAlreadyExist);
                }
                var isUserAdded = await _userRepository.AddUserAsync(userDto);

                if (!isUserAdded.Success)
                {
                    return OperationResult.Failed(Messages.FailedSignUp1);
                }

                return OperationResult.SuccessedResult(true, Messages.SuccessSignUp1);
            }
            catch(Exception ex)
            {
                var error = ex!.ExceptionToErrorDTO("BLL-AuthService");
                var result = await _errorService.LogErrorAsync(error);
                return OperationResult.Failed(result.Message!.ErrorMessage());
            }
        }

        public async Task<OperationResult> LoginWithPasswordAsync(UserViewModel userView)
        {
            try
            {
                var user = await _userRepository.GetByPhoneAsync(userView.PhoneNumber);

                if (!user.Success)
                {
                    return OperationResult.Failed(Messages.userNotLoginWithThisPhoneNumber);
                }
                var isVerified = await _userRepository
                    .VerifyPassword(user.Data.PasswordHash, HashPassword(userView.Password!));

                if (!isVerified.Success)
                {
                    return OperationResult.Failed(Messages.FailedLogin);
                }
                return OperationResult.SuccessedResult();
              
            }
            catch(Exception ex)
            {
                var error = ex!.ExceptionToErrorDTO("BLL-AuthService");
                var result = await _errorService.LogErrorAsync(error);
                return OperationResult.Failed(result.Message!);
            }
    }

        public async Task<OperationResult> LoginWithVerificationCodeAsync(UserViewModel userView)
        {
            var user = await _userRepository.GetByPhoneAsync(userView.PhoneNumber);

            if (!user.Success)
            {
                return OperationResult.Failed(Messages.userNotLoginWithThisPhoneNumber);
            }
            //باید sms بیاد
            var isVerified = await _userRepository
                .VerifyPassword(user.Data.PasswordHash, HashPassword(userView.Password!));

            if (!isVerified.Success)
            {
                if (!isVerified.Success)
                {
                    var error = isVerified.Exception!.ExceptionToErrorDTO(isVerified.Message!);
                    var result = await _errorService.LogErrorAsync(error);
                    return OperationResult.Failed(result.Message!.ErrorMessage());
                }
                return OperationResult.Failed(Messages.userNotLoginWithThisPhoneNumber);
            }
            return OperationResult.SuccessedResult();
        }
        private string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }

     

        public async Task<OperationResult<UserDto>> GetByEmailAsync(string email)
        {
            var result = await _userRepository.GetByEmailAsync(email);
            if (!result.Success)
            {
                if (!result.Success)
                {
                    var error = result.Exception!.ExceptionToErrorDTO(result.Message!);
                    var result1 = await _errorService.LogErrorAsync(error);
                    return OperationResult<UserDto>.Failed(result1.Message!.ErrorMessage());
                }
                return OperationResult<UserDto>.Failed();
            }
            return OperationResult<UserDto>.SuccessedResult(result.Data);

        }

        public async Task<OperationResult<UserDto>> GetByPhoneAsync(string phoneNumber)
        {
            var result = await _userRepository.GetByPhoneAsync(phoneNumber);
            if (!result.Success)
            {
                if (!result.Success)
                {
                    var error = result.Exception!.ExceptionToErrorDTO(result.Message!);
                    var result1 = await _errorService.LogErrorAsync(error);
                    return OperationResult<UserDto>.Failed(result1.Message!.ErrorMessage());
                }
                return OperationResult<UserDto>.Failed();
            }
            return OperationResult<UserDto>.SuccessedResult(result.Data);
        }

       
    }
}
