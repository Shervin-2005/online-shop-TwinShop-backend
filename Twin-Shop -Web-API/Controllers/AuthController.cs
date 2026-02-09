using Microsoft.AspNetCore.Mvc;
using Twin_Shop__Web_API.Controllers;
using Twin_Shop__Web_API.DTOs.Auth;
using Twin_Shop__Web_API.Services.Interfaces;
 

public class AuthController : BaseController
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost]
    public async Task<string> Register(RegisterDto dto)
    {
         var result = await _authService.RegisterAsync(dto);
        return result;
    }

    [HttpPost]
    public async Task<bool> Login(LoginDto dto)
    {
        var result= await _authService.LoginAsync(dto);
        return result;
    }
}
