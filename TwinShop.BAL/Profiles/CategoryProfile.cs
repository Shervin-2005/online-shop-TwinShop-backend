using AutoMapper;
using Twin_Shop__Web_API.DTOs.Category;
using Twin_Shop__Web_API.Entities;

namespace TwinShop.BLL.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryDto>();        // برای نمایش
            CreateMap<CreateCategoryDto, Category>();  // برای Create
        }
    }
}
