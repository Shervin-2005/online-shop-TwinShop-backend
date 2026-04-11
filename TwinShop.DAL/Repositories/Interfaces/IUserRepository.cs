using Twin_Shop__Web_API.Entities;
using TwinShop.Shared;
using TwinShop.Shared.DTOS.Auth;

namespace TwinShop.DAL.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<OperationResult> AddUserAsync(UserDto userDto);
        Task<OperationResult<UserDto>?> GetByPhoneAsync(string phone);
        Task<OperationResult<UserDto>?> GetByEmailAsync(string email);
        Task<OperationResult> PhoneExistsAsync(string phone);
        Task<OperationResult> EmailExistsAsync(string email);
        Task<OperationResult> ChangePasswordAsync(UserDto userDto, string newPassword);
        Task<OperationResult> VerifyPassword(string passwordHashUser, string passwordHashUserDto);
        Task<OperationResult> UpdateUserAsync(UserDto userDto);
    }
}


