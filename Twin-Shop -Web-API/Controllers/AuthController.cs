using Microsoft.AspNetCore.Mvc;
using Twin_Shop__Web_API.Controllers;
using Twin_Shop__Web_API.Services.Interfaces;
using TwinShop.Shared;
using TwinShop.Shared.DTOS.Auth;
using TwinShop.Shared.ViewModels;

public class AuthController : BaseController
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost]
    public async Task<OperationResult> Register([FromBody]UserViewModel userViewModel)
    {
        var result = await _authService.RegisterAsync(userViewModel);
        return result;
    }
    [HttpPost]
    public async Task<OperationResult> EditUserInfo([FromBody] UserViewModel userViewModel,string phoneNumber)
    {
        var result = await _authService.EditUserInfoAsync(userViewModel,phoneNumber);
        return result;
    }


    [HttpPost]
    public async Task<OperationResult> LoginWithPassword([FromBody] LoginUserViewModel userViewModel)
    {
        var result = await _authService.LoginWithPasswordAsync(userViewModel);
        return result;
    }

    [HttpGet]
    public async Task<OperationResult> GetbyEmail(string email)
    {
        var result = await _authService.GetByEmailAsync(email);
        return result;
    }

    [HttpGet]
    public async Task<OperationResult> GetbyPhoneNumber(string phoneNumber)
    {
        var result = await _authService.GetByPhoneAsync(phoneNumber);
        return result;
    }

}
