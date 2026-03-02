using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Twin_Shop__Web_API.Data;
using Twin_Shop__Web_API.Entities;
using TwinShop.DAL.Repositories.Interfaces;

namespace TwinShop.DAL.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        readonly private AppDbContext _dbContext;
        private readonly ILogger<UserRepository> _logger;

        public UserRepository(AppDbContext dbContext, ILogger<UserRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<User?> GetByPhoneAsync(string phone)
        {
            try
            {
                var user = await _dbContext.Users.Where(x => x.PhoneNumber == phone).FirstOrDefaultAsync();
                return user;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting user by phone number: {PhoneNumber}", phone);
                throw new Exception("Failed to get user by phone number", ex);
            } 
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            try
             {
                var user = await _dbContext.Users.Where(x => x.Email == email).FirstOrDefaultAsync();
                return user;
             }
            catch(Exception ex)
             {
                _logger.LogError(ex, "Error getting user by email: {Email}", email);
                throw new Exception("Failed to get user by email", ex);
             }
        }

        public async Task<bool> PhoneExistsAsync(string phone)
        {
            try
            {
                var result = await _dbContext.Users.Where(x => x.PhoneNumber == phone).AnyAsync();
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error checking if phone number exists: {PhoneNumber}", phone);
                throw new Exception("Failed to check if phone number exists", ex);
            }
        }

        public async Task AddUserAsync(User user)
        {
            try
            {
                _dbContext.Users.Add(user);
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "Error adding user: {User}", user);
                throw new Exception("Failed to add user", ex);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error adding user: {User}", user);
                throw;
            }
        }

        public async Task<bool> ChangePasswordAsync(User user)
        {
            try
            {
                var existingUser = await _dbContext.Users.FirstOrDefaultAsync(u => u.UserId == user.UserId);

                if (existingUser != null)
                {
                    existingUser.PasswordHash = user.PasswordHash;
                    await _dbContext.SaveChangesAsync();
                    return true;
                }
                else
                {
                    _logger.LogError("No user found with UserId: {UserId}", user.UserId);
                    throw new Exception("No user found with the provided UserId");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error changing password for user: {User}", user);
                return false;
            }
        }
    }

}
