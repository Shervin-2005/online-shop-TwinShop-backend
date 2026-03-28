using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwinShop.Shared.DTOS.Auth;
using TwinShop.Shared.ViewModels;

namespace TwinShop.Shared.Mappers
{
    public static class UserMapper
    {
        public static UserDto ToUserDTO(this UserViewModel userView)
        {
            return new UserDto
            {
                FirstName = userView.FirstName,
                LastName = userView.LastName,
                PhoneNumber = userView.PhoneNumber,
                Email = userView.Email,
                PasswordHash = userView.Password
            };
        }
        public static UserViewModel ToUserViewModel(this UserDto userDto)
        {
            return new UserViewModel
            {
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                PhoneNumber = userDto.PhoneNumber,
                Email = userDto.Email,
                Password = userDto.PasswordHash,
            };
        }
    }
}
