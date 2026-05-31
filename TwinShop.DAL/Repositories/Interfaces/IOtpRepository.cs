using TwinShop.DAL.Entities;

namespace TwinShop.DAL.Repositories.Interfaces
{
    public interface IOTPRepository
    {
        Task SaveOTP(string mobile, string code, DateTime expireTime);
        Task <OTP> GetOTP(string mobile);
        Task<bool> DeleteOTP(string mobile);
    }
}
