using AutoMapper;
using Twin_Shop__Web_API.DTOs.Auth;
using Twin_Shop__Web_API.Entities;
using TwinShop.Shared.DTOS.Auth;

namespace TwinShop.BLL.Profiles
{
    public class Auth_Profile:Profile
    {
        public Auth_Profile()
        {
            CreateMap<User, RegisterDto>();
            CreateMap<RegisterDto,User>();
            CreateMap<User,UserDto>();
            CreateMap<UserDto, User>();
        }
    }
}
