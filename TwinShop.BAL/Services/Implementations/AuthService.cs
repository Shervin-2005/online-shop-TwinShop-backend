using System.Security.Cryptography;
using System.Text;
using AutoMapper;
using Twin_Shop__Web_API.DTOs.Auth;
using Twin_Shop__Web_API.Entities;
using Twin_Shop__Web_API.Services.Interfaces;
using TwinShop.DAL.Repositories.Interfaces;
using TwinShop.Shared.DTOS.Auth;
namespace Twin_Shop__Web_API.Services.Implementations
{
    public class AuthService : IAuthService
    {

        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;


        public AuthService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
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
                await _userRepository.AddUserAsync(user);
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
            if (user == null)
            {
                return false;
            }
            var result = VerifyPassword(dto.Password, user.PasswordHash);
            if (!result)
            {
                return false;
            }
            return true;
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

        public async Task<UserDto> GetByEmailAsync(string email)
        {
            var user= await _userRepository.GetByEmailAsync(email);
            return _mapper.Map<UserDto>(user);
        }
        public async Task<UserDto> GetByPhoneAsync(string phoneNumber)
        {
            var user =await _userRepository.GetByPhoneAsync(phoneNumber);
            return _mapper.Map<UserDto>(user);
        }
    }
}

