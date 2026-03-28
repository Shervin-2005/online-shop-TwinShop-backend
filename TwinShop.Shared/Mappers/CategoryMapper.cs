using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twin_Shop__Web_API.DTOs.Category;
using Twin_Shop__Web_API.DTOs.Product;
using TwinShop.Shared.ViewModels;

namespace TwinShop.Shared.Mappers
{
    public static class CategoryMapper
    {
        public static CategoryDto ToCategoryDTO(this CategoryViewModel categoryView)
        {
            return new CategoryDto
            {
               CategoryName = categoryView.CategoryName,
               MainImage = categoryView.MainImage,
            };
        }
        public static CategoryViewModel ToCategoryViewModel(this CategoryDto categoryDto)
        {
            return new CategoryViewModel
            {
                CategoryName=categoryDto.CategoryName,
                MainImage=categoryDto.MainImage,
            };
        }
    }
}
