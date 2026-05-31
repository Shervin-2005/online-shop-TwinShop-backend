using Microsoft.EntityFrameworkCore;
using Twin_Shop__Web_API.Entities;
using TwinShop.DAL.Data;
using TwinShop.DAL.Repositories.Interfaces;
using TwinShop.Shared.Custom_Exceptions;
using TwinShop.Shared.DTOS.Auth;

namespace TwinShop.DAL.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        readonly private AppDbContext _dbContext;

        public UserRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<UserDto?> GetUserByPhoneAsync(string phone)
        {
            try
            {
                 return await _dbContext.Users
                .AsNoTracking()
                .Where(u => u.PhoneNumber == phone)
                .Select(u => new UserDto
                {
                    Id = u.UserId,
                    ProfileImage = u.ProfileImage,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    PhoneNumber = u.PhoneNumber,
                    PasswordHash = u.PasswordHash,
                    Email = u.Email,
                })
                .FirstOrDefaultAsync();
            }
            catch (Exception ex) when (ex is not AppException)
            {
                throw new DatabaseException("Failed to retrieve user", ex);
            }
        }
        public async Task<UserDto?> GetByEmailAsync(string email)
        {
            try
            {
                return await _dbContext.Users
               .AsNoTracking()
               .Where(u => u.Email == email)
               .Select(u => new UserDto
               {
                   Id = u.UserId,
                   ProfileImage = u.ProfileImage,
                   FirstName = u.FirstName,
                   LastName = u.LastName,
                   PhoneNumber = u.PhoneNumber,
                   PasswordHash = u.PasswordHash,
                   Email = u.Email,
               })
               .FirstOrDefaultAsync();
            }
            catch (Exception ex) when (ex is not AppException)
            {
                throw new DatabaseException("Failed to retrieve user", ex);
            }
        }
        public async Task<bool> PhoneExistsAsync(string phone)
        {
            try
            {
                return await _dbContext.Users.Where(x => x.PhoneNumber == phone).AnyAsync();
            }
            catch (Exception ex) when (ex is not AppException)
            {
                throw new DatabaseException("Failed to check PhoneNumber.", ex);
            }
        }
        public async Task<bool> EmailExistsAsync(string email)
        {
            try
            {
                return await _dbContext.Users.Where(x => x.Email == email).AnyAsync();
            }
            catch (Exception ex) when (ex is not AppException)
            {
                throw new DatabaseException("Failed to check Email.", ex);
            }
        }
        public async Task<int> AddUserAsync(UserDto userDto)
        {
            try
            {
                User user = new User
                {
                    PhoneNumber = userDto.PhoneNumber,
                    PasswordHash = userDto.PasswordHash,
                    ProfileImage = userDto.ProfileImage,
                };
                _dbContext.Users.Add(user);
                await _dbContext.SaveChangesAsync();

                return user.UserId;
            }
            catch (Exception ex) when (ex is not AppException)
            {
                throw new DatabaseException("Failed to create user", ex);
            }

        }
        public async Task<bool> UpdateUserAsync(UserDto userDto, int id)
        {
            try
            {
                var existingUser = await _dbContext.Users
                .FirstOrDefaultAsync(u => u.UserId == id);

                if (existingUser == null) return false;

                existingUser!.FirstName = userDto.FirstName;
                existingUser.LastName = userDto.LastName;
                existingUser.Email = userDto.Email;
                existingUser.PhoneNumber = userDto.PhoneNumber!;
                existingUser.ProfileImage = userDto.ProfileImage!;

                await _dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception ex) when (ex is not AppException)
            {
                throw new DatabaseException("Failed to update user", ex);
            }
        }
        public async Task<bool> UpdateUserPassword(UserDto userDto)
        {
            try
            {
                var existingUser = await _dbContext.Users
               .FirstOrDefaultAsync(u => u.UserId == userDto.Id);

                if (existingUser == null) return false;

                existingUser.PasswordHash = userDto.PasswordHash;

                await _dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception ex) when (ex is not AppException)
            {
                throw new DatabaseException("Failed to change password", ex);
            }
        }
    }

}
