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
        public static CategoryDto CategoryCardViewModelToCategoryDTO(this CategoryViewModel categoryView)
        {
            return new CategoryDto
            {
                CategoryId = categoryView.CategoryId,
                CategoryName = categoryView.CategoryName,
                MainImage = categoryView.MainImage,
            };
        }
        public static CategoryViewModel CategoryDTOToCategoryCardViewModel(this CategoryDto categoryDto)
        {
            return new CategoryViewModel
            {
                CategoryName = categoryDto.CategoryName,
                MainImage = categoryDto.MainImage,
                CategoryId = categoryDto.CategoryId,
            };
        }
        public static List<CategoryViewModel> CategoryDTOToCategoryCardViewModel(this List<CategoryDto> categories)
        {
            return categories.Select(c => c.CategoryDTOToCategoryCardViewModel()).ToList();
        }
    }
}
