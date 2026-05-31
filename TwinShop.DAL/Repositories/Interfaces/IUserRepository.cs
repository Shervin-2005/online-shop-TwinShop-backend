using Microsoft.EntityFrameworkCore;
using Twin_Shop__Web_API.Entities;
using TwinShop.Shared;
using TwinShop.Shared.DTOS.Auth;

namespace TwinShop.DAL.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<int> AddUserAsync(UserDto userDto);
        Task<UserDto?> GetUserByPhoneAsync(string phone);
        Task<UserDto?> GetByEmailAsync(string email);
        Task<bool> PhoneExistsAsync(string phone);
        Task<bool> EmailExistsAsync(string email);
        Task<bool> UpdateUserAsync(UserDto userDto, int id);
        Task<bool> UpdateUserPassword(UserDto userDto);
    }
}


