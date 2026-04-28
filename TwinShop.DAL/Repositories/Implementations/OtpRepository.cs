using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwinShop.DAL.Data;
using TwinShop.DAL.Entities;
using TwinShop.DAL.Repositories.Interfaces;
using TwinShop.Shared;

namespace TwinShop.DAL.Repositories.Implementations
{
    public class OtpRepository : IOtpRepository
    {
        private readonly AppDbContext _dbContext;

        public OtpRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult> DeleteOtp(string mobile)
        {
            try
            {
                var otp = await _dbContext.Otps
                    .FirstOrDefaultAsync(o => o.Mobile == mobile);

                if (otp != null)
                {
                    _dbContext.Otps.Remove(otp);
                    await _dbContext.SaveChangesAsync();
                }

                return OperationResult.SuccessedResult();
            }
            catch (Exception ex)
            {
                return OperationResult.Failed(GetType().Name, ex);
            }
        }

        public async Task<OperationResult<Otp>> GetOtp(string mobile)
        {
            try
            {
                var otp = await _dbContext.Otps
                    .AsNoTracking()
                    .FirstOrDefaultAsync(o => o.Mobile == mobile);

                return otp != null
                    ? OperationResult<Otp>.SuccessedResult(otp)
                    : OperationResult<Otp>.Failed("کد OTP یافت نشد");
            }
            catch (Exception ex)
            {
                return OperationResult<Otp>.Failed(GetType().Name, ex);
            }
        }

        public async Task<OperationResult> SaveOtp(string mobile, string code, DateTime expireTime)
        {
            try
            {
                var existingOtp = await _dbContext.Otps
                    .FirstOrDefaultAsync(o => o.Mobile == mobile);

                if (existingOtp != null)
                {
                    _dbContext.Otps.Remove(existingOtp);
                }

                var otp = new Otp
                {
                    Mobile = mobile,
                    Code = code,
                    ExpireTime = expireTime,
                };

                _dbContext.Otps.Add(otp);
                await _dbContext.SaveChangesAsync();

                return OperationResult.SuccessedResult();
            }
            catch (Exception ex)
            {
                return OperationResult.Failed(GetType().Name, ex);
            }
        }
    }
}
