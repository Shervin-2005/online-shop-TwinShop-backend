using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TwinShop.Shared.DTOS;
using TwinShop.Shared.DTOS.Auth;
using TwinShop.Shared.ViewModels.UserViewModels;

namespace TwinShop.Shared.Mappers
{
    public static class UserMapper
    {
        public static UserDto RegisterViewToUserDTO(this RegisterUserViewModel registerUserView)
        {
            return new UserDto
            {
                PhoneNumber = registerUserView.PhoneNumber,
                PasswordHash = HashPassword(registerUserView.Password!),
                ProfileImage = MessagesAndConsts.DefaultProfile
            };
        }
        public static UserDto UserInfoViewToUserDTO(this UserInfoViewModel userInfoViewModel)
        {
            return new UserDto
            {
                Id = userInfoViewModel.Id,
                FirstName = userInfoViewModel.FirstName,
                LastName = userInfoViewModel.LastName,
                PhoneNumber = userInfoViewModel.PhoneNumber,
                Email = userInfoViewModel.Email,
                ProfileImage = userInfoViewModel.ProfileImage,
            };
        }
        public static UserInfoViewModel UserDTOToUserInfoViewModel(this UserDto userDto)
        {
            return new UserInfoViewModel
            {
                Id=userDto.Id,
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                PhoneNumber = userDto.PhoneNumber,
                Email = userDto.Email,
                ProfileImage=userDto.ProfileImage,
            };
        }
        public static string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }
    }
}
