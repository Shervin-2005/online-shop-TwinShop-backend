using AutoMapper;
using Twin_Shop__Web_API.DTOs.Auth;
using Twin_Shop__Web_API.Entities;

namespace TwinShop.BLL.Profiles
{
    public class Auth_Profile:Profile
    {
        public Auth_Profile()
        {
            CreateMap<User, RegisterDto>();
        }
    }
}
