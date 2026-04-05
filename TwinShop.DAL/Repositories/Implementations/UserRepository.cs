using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Twin_Shop__Web_API.Entities;
using TwinShop.DAL.Data;
using TwinShop.DAL.Repositories.Interfaces;
using TwinShop.Shared;
using TwinShop.Shared.DTOS;
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

        public async Task<OperationResult<UserDto>?> GetByPhoneAsync(string phone)
        {         
                var user = await _dbContext.Users.AsNoTracking().Where(u => u.PhoneNumber == phone)
                    .Select(u => new UserDto
                    {
                        FirstName = u.FirstName,
                        LastName = u.LastName,
                        PhoneNumber= u.PhoneNumber,
                        Email = u.Email,
                        PasswordHash = u.PasswordHash,
                    }).FirstOrDefaultAsync();
           
            return user!=null ?OperationResult<UserDto>.SuccessedResult(user): OperationResult<UserDto>.Failed(Messages.userNotLoginWithThisPhoneNumber);
        }
       

        public async Task<OperationResult<UserDto>?> GetByEmailAsync(string email)
        {
            try
            {
                var user = await _dbContext.Users.AsNoTracking().Where(u => u.Email == email)
                    .Select(u => new UserDto
                    {
                        FirstName = u.FirstName,
                        LastName = u.LastName,
                        PhoneNumber = u.PhoneNumber,
                        Email = u.Email,
                    }).FirstOrDefaultAsync();
                return OperationResult<UserDto>.SuccessedResult(user);
            }
            catch (Exception ex)
            {
                return OperationResult<UserDto>.Failed(GetType().Name, ex);
            }
        }
        
        public async Task<OperationResult> PhoneExistsAsync(string phone)
        {
            var user= await _dbContext.Users.Where(x => x.PhoneNumber == phone).FirstOrDefaultAsync();

            return user != null ? OperationResult.SuccessedResult() : OperationResult<UserDto>.Failed();
        }

        public async Task<OperationResult> EmailExistsAsync(string email)
        {
            try
            {
                await _dbContext.Users.Where(x => x.Email == email).AnyAsync();
                return OperationResult.SuccessedResult();
            }
            catch (Exception ex)
            {
                return OperationResult.Failed(GetType().Name, ex);
            }
        }

        public async Task<OperationResult> AddUserAsync(UserDto userDto)
        {
           
                User user = new User
                {
                   PhoneNumber= userDto.PhoneNumber,
                    PasswordHash=userDto.PasswordHash
                };
                _dbContext.Users.Add(user);
                await _dbContext.SaveChangesAsync();
                return OperationResult.SuccessedResult();
            
        }
        //اشتباهه باید اصلاح بشه
        public async Task<OperationResult>ChangePasswordAsync(UserDto userDto,string newPassword)
        {
            try
            {
                var existingUser = await _dbContext.Users.FirstAsync();
                existingUser.PasswordHash = userDto.PasswordHash;
                await _dbContext.SaveChangesAsync();
                return OperationResult.SuccessedResult();
            }
            catch (Exception ex)
            {
                return OperationResult.Failed(GetType().Name, ex);
            }
        }

        public async Task<OperationResult> VerifyPassword(string passwordHashUser,string passwordHashUserDto)
        {
            bool result= (passwordHashUser == passwordHashUserDto);
            if(result) return OperationResult.SuccessedResult();
            else return OperationResult.Failed(Messages.IncorrectPhoneNumberOrPassword);
        }

        public async Task<OperationResult> UpdateUser(UserDto userDto,int id)
        {
            try
            {
                var existing = await _dbContext.Users.Where(u => u.UserId == id).FirstAsync();

                existing.FirstName = userDto.FirstName;
                existing.LastName = userDto.LastName;
                existing.Email = userDto.Email;
                existing.PhoneNumber = userDto.PhoneNumber;  
                existing.ProflileImage = userDto.ProflileImage;

                await _dbContext.SaveChangesAsync();
                return OperationResult.SuccessedResult(); ;
            }
            catch (Exception ex)
            {
                return OperationResult.Failed(GetType().Name, ex);
            }
        }
    }

}
