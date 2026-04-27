using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TwinShop.BLL.Services.Interfaces;
using TwinShop.DAL.Entities;
using TwinShop.DAL.Repositories.Interfaces;
using TwinShop.Shared;
using TwinShop.Shared.DTOS;
using TwinShop.Shared.ViewModels.UserViewModels;

namespace TwinShop.BLL.Services.Implementations
{
    public class SmsService : ISmsService
    {
        private readonly IOtpRepository? _otp;
        private readonly string _apiKey = "gGpmMoUBinyjMmpkzud1y0OMqvq5cpWljM1APNLXOop55MlX";
        private readonly int _templateId = 791299;

        public SmsService(IOtpRepository otp)
        {
            _otp = otp;
        }
        public async Task<OperationResult> SendOtp(string mobile)
        {
            string code = new Random().Next(10000, 99999).ToString();

            var saveOtpResult = await _otp!.SaveOtp(mobile, code, DateTime.Now.AddMinutes(2));

            if (!saveOtpResult.Success)
            {
                return OperationResult.Failed(MessagesAndConsts.FailedSendCode);
            }
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("x-api-key", _apiKey);

                var model = new
                {
                    Mobile = mobile,
                    TemplateId = _templateId,
                    Parameters = new[]
                    {
                    new { Name = "Code", Value = code }
                    }
                };

                string payload = JsonSerializer.Serialize(model);
                StringContent content = new(payload, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await httpClient.PostAsync(
                    "https://api.sms.ir/v1/send/verify",
                    content
                );

                return OperationResult.SuccessedResult(true, MessagesAndConsts.SendCode);
            }
        }
        public async Task<OperationResult> VerifyOtp(LoginWithCodeUserViewModel loginWithCodeUserViewModel)
        {
            var savedOtpResult = await _otp?.GetOtp(loginWithCodeUserViewModel.PhoneNumber!)!;

            if (!savedOtpResult.Success)
            {
                return OperationResult.Failed(MessagesAndConsts.CodeNotFound);
            }

            var savedOtp = savedOtpResult.Data;

            if (savedOtp.ExpireTime < DateTime.Now)
                return OperationResult.Failed("کد تایید منقضی شده است. لطفاً دوباره درخواست ارسال کد دهید");

            if (savedOtp.Code == loginWithCodeUserViewModel.Code)
            {
               await _otp?.DeleteOtp(loginWithCodeUserViewModel.PhoneNumber!);
                return OperationResult.SuccessedResult(true,"ورود با موفقیت انجام شد");
                
            }
            return OperationResult.Failed("کد وارد شده صحیح نیست. لطفاً دوباره تلاش کنید.");
        }   
    }
}
