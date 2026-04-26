using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwinShop.DAL.Entities;
using TwinShop.Shared;

namespace TwinShop.DAL.Repositories.Interfaces
{
    public interface IOtpRepository
    {
        Task<OperationResult> SaveOtp(string mobile, string code, DateTime expireTime);
        Task<OperationResult<Otp>> GetOtp(string mobile);
        Task<OperationResult> DeleteOtp(string mobile);
    }
}
