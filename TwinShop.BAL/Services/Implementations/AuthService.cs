using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Security.Cryptography;
using System.Text;
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
        private readonly ILogger<AuthService> _logger;

        public AuthService(IUserRepository userRepository, IMapper mapper,ILogger<AuthService> logger)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _logger = logger;
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
                return "Register Successfully!!";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while registering the user: {PhoneNumber}", dto.PhoneNumber);
                return "Something went wrong 😖";
            }
        }

        public async Task<bool> LoginAsync(LoginDto dto)
        {
            try
            {
                var user = await _userRepository.GetByPhoneAsync(dto.PhoneNumber);
                if (user == null)
                {
                    _logger.LogWarning("User not found with phone number: {PhoneNumber}", dto.PhoneNumber);
                    return false;
                }
                var result = VerifyPassword(dto.Password, user.PasswordHash);
                if (!result)
                {
                    _logger.LogInformation("Invalid password for user: {PhoneNumber}", dto.PhoneNumber);
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while logging in the user: {PhoneNumber}", dto.PhoneNumber);
                return false;
            }
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
            try
            {
                var user = await _userRepository.GetByEmailAsync(email);
                if (user == null)
                {
                    _logger.LogWarning("User not found with email: {Email}", email);
                    return null;
                }
                return _mapper.Map<UserDto>(user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving user by email: {Email}", email);
                throw; 
            }
        }

        public async Task<UserDto> GetByPhoneAsync(string phoneNumber)
        {
            try
            {
                var user = await _userRepository.GetByPhoneAsync(phoneNumber);
                if (user == null)
                {
                    _logger.LogWarning("User not found with phone number: {PhoneNumber}", phoneNumber);
                    return null;
                }
                return _mapper.Map<UserDto>(user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving user by phone number: {PhoneNumber}", phoneNumber);
                throw; 
            }
        }
    }
}
