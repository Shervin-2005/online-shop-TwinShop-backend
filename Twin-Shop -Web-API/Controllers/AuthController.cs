using Microsoft.AspNetCore.Mvc;
using Twin_Shop__Web_API.Controllers;
using Twin_Shop__Web_API.DTOs.Auth;
using Twin_Shop__Web_API.Services.Interfaces;
using TwinShop.Shared.DTOS.Auth;

public class AuthController : BaseController
{
    private readonly IAuthService _authService;
    private readonly ILogger<AuthController> _logger;

    public AuthController(IAuthService authService,ILogger<AuthController> logger)
    {
        _authService = authService;
        _logger = logger;
    }

    [HttpPost]
    public async Task<IActionResult> Register([FromBody]RegisterDto dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        try
        {
            var result = await _authService.RegisterAsync(dto);
            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while registering user.");

            return StatusCode(StatusCodes.Status500InternalServerError, new { error = "Internal server error" });

        }

    }

    [HttpPost]
    public async Task<IActionResult> Login([FromBody] LoginDto dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        try
        {
            var result = await _authService.LoginAsync(dto);
            return Ok(result);
        }
        catch(Exception ex)
        {
            _logger.LogError(ex, "An error occurred while logging in user.");

            return StatusCode(StatusCodes.Status500InternalServerError, new { error = "Internal server error" });

        }

    }

    [HttpGet]
    public async Task<IActionResult> GetbyEmail(string email)
    {
        try
        {
            var user = await _authService.GetByEmailAsync(email);
            if(user==null) return NotFound(new { message = "User not found" });
            return Ok(user);
        }
        catch(Exception ex)
        {
            _logger.LogError(ex, "An error occurred while retrieving user by email.");
            return StatusCode(StatusCodes.Status500InternalServerError, new { error = "Internal server error" });
        }
    }
    [HttpGet]
    public async Task<IActionResult> GetbyPhoneNumber(string phoneNumber)
    {
        try
        {
            var user = await _authService.GetByPhoneAsync(phoneNumber);
            if(user==null) return NotFound(new { message = "User not found" });
            return Ok(user);
        }
        catch(Exception ex)
        {
            _logger.LogError(ex, "An error occurred while retrieving user by phonenumber.");
            return StatusCode(StatusCodes.Status500InternalServerError, new { error = "Internal server error" });
        }
    }
}
