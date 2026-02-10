using Microsoft.EntityFrameworkCore;
using System.Numerics;
using Twin_Shop__Web_API.Data;
using Twin_Shop__Web_API.Entities;
using Twin_Shop__Web_API.Repositories.Implementations;

public class UserRepository : IUserRepository
{
    readonly private AppDbContext _dbContext;

    public UserRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<User?> GetByPhoneAsync(string phone)
    {
        var user = await _dbContext.Users.Where(x => x.PhoneNumber == phone).FirstOrDefaultAsync();
        return user;
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        var user = await _dbContext.Users.Where(x => x.Email == email).FirstOrDefaultAsync();
        return user;
    }

    public async Task<bool> PhoneExistsAsync(string phone)
    {
        var result = await _dbContext.Users.Where(x => x.PhoneNumber == phone).AnyAsync();
        return result;
    }

    public async Task AddUserAsync(User user)
    {
        _dbContext.Users.Add(user);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<bool> ChangePasswordAsync(User user)
    {
        try
        {
            var existingUser = _dbContext.Users.FirstOrDefault(u => u.UserId == user.UserId);

            existingUser.PasswordHash = user.PasswordHash;

            return true;
        }
        catch (Exception ex)
        {
            return false;

        }
    }
}
