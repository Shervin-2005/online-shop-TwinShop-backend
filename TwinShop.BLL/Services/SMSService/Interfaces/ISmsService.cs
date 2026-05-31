namespace TwinShop.BLL.Services.SMSService.Interfaces
{
    public interface ISmsService
    {
        Task SendOtp(string mobile);
        Task<bool> VerifyOtp(string mobile, string code);
    }
}
