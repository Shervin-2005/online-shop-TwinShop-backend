using Microsoft.AspNetCore.Mvc;
using Twin_Shop__Web_API.Controllers;
using Twin_Shop__Web_API.Services.Interfaces;
using TwinShop.BLL.Services.Implementations;
using TwinShop.BLL.Services.Interfaces;
using TwinShop.Shared;
using TwinShop.Shared.DTOS.Auth;
using TwinShop.Shared.ViewModels.UserViewModels;

public class AuthController : BaseController
{
    private readonly IAuthService _authService;
    private readonly ISmsService _smsService;
    public AuthController(IAuthService authService, ISmsService smsService)
    {
        _authService = authService;
        _smsService = smsService;
    }

    [HttpPost]
    public async Task<OperationResult> Register([FromBody]RegisterUserViewModel registerUserViewModel)
    {
        var result = await _authService.RegisterAsync(registerUserViewModel);
        return result;
    }
    [HttpPost]
    public async Task<OperationResult> EditUserInfo([FromBody] UserInfoViewModel userInfoViewModel,string phoneNumber)
    {
        var result = await _authService.EditUserInfoAsync(userInfoViewModel, phoneNumber);
        return result;
    }
    [HttpPost]
    public async Task<OperationResult> ChangePassword([FromBody] ChangePasswordUserViewModel changePasswordUserViewModel, string phoneNumber)
    {
        var result = await _authService.ChangePasswordAsync(changePasswordUserViewModel, phoneNumber);
        return result;
    }


    [HttpPost]
    public async Task<OperationResult> LoginWithPassword([FromBody] LoginUserViewModel loginUserViewModel)
    {
        var result = await _authService.LoginWithPasswordAsync(loginUserViewModel);
        return result;
    }

    [HttpGet]
    public async Task<OperationResult> GetbyEmail(string email)
    {
        var result = await _authService.GetByEmailAsync(email);
        return result;
    }

    [HttpGet]
    public async Task<OperationResult> GetUserbyPhoneNumber(string phoneNumber)
    {
        var result = await _authService.GetUserByPhoneAsync(phoneNumber);
        return result;
    }

    [HttpPost]
    public async Task<OperationResult> SendOtp([FromBody]string phoneNumber)
    {
        var result = await _smsService.SendOtp(phoneNumber);
        return result;
    }

    [HttpPost]
    public async Task<OperationResult> VerifyOtp([FromBody]LoginWithCodeUserViewModel loginWithCodeUserViewModel)
    {
        var result =await _smsService.VerifyOtp(loginWithCodeUserViewModel);
        return result;
    }

}
