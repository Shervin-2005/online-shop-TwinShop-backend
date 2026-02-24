using AutoMapper;
using Twin_Shop__Web_API.DTOs.Brand;
using Twin_Shop__Web_API.Entities;

namespace TwinShop.BLL.Profiles
{
    public class BrandProfile:Profile
    {
        public BrandProfile()
        {
            CreateMap<Brand, BrandDto>();       
            CreateMap<CreateBrandDto, Brand>();  
        }
    }
}
