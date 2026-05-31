using Microsoft.AspNetCore.Mvc;
using Twin_Shop__Web_API.Controllers;
using Twin_Shop__Web_API.Services.Interfaces;
using TwinShop.BLL.Services.SMSService.Interfaces;
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

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody]RegisterUserViewModel registerUserViewModel)
    {
        var userId = await _authService.RegisterAsync(registerUserViewModel);

        return Created();
    }

    [HttpPut("profile/{phoneNumber}")]
    [Consumes("multipart/form-data")]
    public async Task<IActionResult> EditUserInfo([FromBody] UserInfoViewModel userInfoViewModel, string phoneNumber, int userId)
    {
        await _authService.EditUserInfoAsync(userInfoViewModel, phoneNumber, userId);
        return NoContent();
    }


    [HttpPut("change-password/{phoneNumber}")]
    public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordUserViewModel changePasswordUserViewModel, string phoneNumber)
    {
        await _authService.ChangePasswordAsync(changePasswordUserViewModel, phoneNumber);
        return NoContent();
    }

    [HttpPost("login")]
    public async Task<IActionResult> LoginWithPassword([FromBody] LoginUserViewModel loginUserViewModel)
    {
        var result = await _authService.LoginWithPasswordAsync(loginUserViewModel);
        return Ok(result);
    }

    [HttpPost("send-otp")]
    public async Task<IActionResult> SendOtp([FromBody] string mobile)
    {
        await _smsService.SendOtp(mobile);
        return NoContent();
    }

    [HttpPost("verify-otp")]
    public async Task<IActionResult> VerifyOtp([FromBody] OtpVerifyViewModel otpVerifyViewModel)
    {
        var result = await _smsService.VerifyOtp(otpVerifyViewModel.Mobile!, otpVerifyViewModel.Code!);
        return Ok(result);
    }

}
