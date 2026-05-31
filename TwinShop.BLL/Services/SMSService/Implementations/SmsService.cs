using Microsoft.Extensions.Options;
using System.Text;
using System.Text.Json;
using TwinShop.BLL.Services.SMSService.Interfaces;
using TwinShop.BLL.Services.SMSService.Options;
using TwinShop.DAL.Repositories.Interfaces;
using TwinShop.Shared.Custom_Exceptions;

namespace TwinShop.BLL.Services.SMSService.Implementations
{
    public class SmsService : ISmsService
    {
        private readonly IOTPRepository? _OTPRepository;
        private readonly OTPOptions _oTPOptions;
        private readonly IHttpClientFactory _httpClientFactory;

        public SmsService(IOTPRepository OTPRepository, IOptions<OTPOptions> oTPOptions, IHttpClientFactory httpClientFactory)
        {
            _OTPRepository = OTPRepository;
            _oTPOptions = oTPOptions.Value;
            _httpClientFactory = httpClientFactory;
        }
        public async Task SendOtp (string mobile)
        {
            if (mobile == null)
                throw new BadRequestException("Your number is not found");

            string code = Random.Shared.Next(10000, 99999).ToString();

            await _OTPRepository!.SaveOTP(mobile, code, DateTime.Now.AddMinutes(2));

            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Add("x-api-key", _oTPOptions.OtpApiKey);

            var model = new
            {
                Mobile = mobile,
                TemplateId = _oTPOptions.OtpTemplateId,
                Parameters = new[]
                {
                    new { Name = "Code", Value = code }
                }
            };

            string payload = JsonSerializer.Serialize(model);
            StringContent content = new(payload, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync(
                "https://api.sms.ir/v1/send/verify",
                content
            );

            if (!response.IsSuccessStatusCode)
                throw new HttpRequestException($"SMS sending failed. Status: {response.StatusCode}");
        }
        public async Task<bool> VerifyOtp(string mobile, string code)
        {
            if (mobile == null)
                throw new BadRequestException("Your number is not found");

            var savedOTP = await _OTPRepository!.GetOTP(mobile)!;

            if (savedOTP == null || savedOTP.ExpireTime < DateTime.Now)
                throw new UnauthorizedException("The code has been expired");

            if (savedOTP.Code == code) return true;
            else return false;
        }   
    }
}
