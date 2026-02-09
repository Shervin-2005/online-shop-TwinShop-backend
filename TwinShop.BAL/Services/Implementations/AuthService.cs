using Twin_Shop__Web_API.DTOs.Auth;
using Twin_Shop__Web_API.Entities;
using Twin_Shop__Web_API.Repositories.Interfaces;
using Twin_Shop__Web_API.Services.Interfaces;
using System.Security.Cryptography;
using System.Text;


public class AuthService : IAuthService
{

    private readonly IUserRepository _userRepository;

    public AuthService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<string> RegisterAsync(RegisterDto dto)
    {
        try
        {
            var result = await _userRepository.PhoneExistsAsync(dto.PhoneNumber);
            if (result)
            {
                return "This phone number already exists";
            }

            var user = new User
            {
                PhoneNumber = dto.PhoneNumber,
                PasswordHash = HashPassword(dto.Password),
                Email = dto.Email
            };
            await _userRepository.AddUser(user);
            return "Register Succsesfully!!";
        }
        catch (Exception ex)
        {
            return "Something went wrong 😖";
        }
    }

    public async Task<bool> LoginAsync(LoginDto dto)
    {
        var user = await _userRepository.GetByPhoneAsync(dto.PhoneNumber);
        if (user == null) return false;

        return VerifyPassword(dto.Password, user.PasswordHash);
    }

    private string HashPassword(string password)
    {
        using var sha256 = SHA256.Create();
        var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
        return Convert.ToBase64String(bytes);
    }

    private bool VerifyPassword(string password, string hash)
    {
        return HashPassword(password) == hash;
    }
}
