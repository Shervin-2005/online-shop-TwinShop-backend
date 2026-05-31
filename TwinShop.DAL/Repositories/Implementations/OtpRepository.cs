using Microsoft.EntityFrameworkCore;
using TwinShop.DAL.Data;
using TwinShop.DAL.Entities;
using TwinShop.DAL.Repositories.Interfaces;
using TwinShop.Shared.Custom_Exceptions;
using static System.Net.WebRequestMethods;

namespace TwinShop.DAL.Repositories.Implementations
{
    public class OTPRepository : IOTPRepository
    {
        private readonly AppDbContext _dbContext;

        public OTPRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> DeleteOTP(string mobile)
        {
            try
            {
                var otp = await _dbContext.OTPs
                .FirstOrDefaultAsync(o => o.Mobile == mobile);

                if(otp == null) return false;

                _dbContext.OTPs.Remove(otp);
                await _dbContext.SaveChangesAsync();
                 
                return true;
            }
            catch (Exception ex) when (ex is not AppException)
            {
                throw new DatabaseException("Failed to delete OTP.", ex);
            }
        }

        public async Task<OTP> GetOTP(string mobile)
        {
            try
            {
                var otp = await _dbContext.OTPs
               .AsNoTracking()
               .FirstOrDefaultAsync(o => o.Mobile == mobile);

                return otp!;
            }
            catch (Exception ex) when (ex is not AppException)
            {
                throw new DatabaseException("Failed to retrieve OTP.", ex);
            }
        }
        public async Task SaveOTP(string mobile, string code, DateTime expireTime)
        {
            try
            {
                var existingOtp = await _dbContext.OTPs
                   .FirstOrDefaultAsync(o => o.Mobile == mobile);

                if (existingOtp != null)
                {
                    _dbContext.OTPs.Remove(existingOtp);
                }

                var otp = new OTP
                {
                    Mobile = mobile,
                    Code = code,
                    ExpireTime = expireTime,
                };

                _dbContext.OTPs.Add(otp);

                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex) when (ex is not AppException)
            {
                throw new DatabaseException("Failed to save OTP.", ex);
            }
        }
    }
}
