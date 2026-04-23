using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twin_Shop__Web_API.DTOs.Brand;
using Twin_Shop__Web_API.DTOs.Category;
using Twin_Shop__Web_API.DTOs.Product;
using TwinShop.Shared.ViewModels;

namespace TwinShop.Shared.Mappers
{
    public static class BrandMapper
    {
        public static BrandDto BrandViewModelToBrandDTO(this BrandViewModel brandView)
        {
            return new BrandDto
            {
                BrandId = brandView.BrandId,
                BrandName = brandView.BrandName,
                MainImage = brandView.MainImage,
                CategoryName = brandView.CategoryName,
                IsDeleted = brandView.IsDeleted,
                CategoryId = brandView.CategoryId,
            };
        }
        public static BrandViewModel BrandDTOToBrandViewModel(this BrandDto brand)
        {
            return new BrandViewModel
            {
                BrandId= brand.BrandId,
                BrandName = brand.BrandName,
                MainImage = brand.MainImage,
                CategoryName = brand.CategoryName,
                IsDeleted = brand.IsDeleted,
                CategoryId = brand.CategoryId,
            };
        }
        public static List<BrandViewModel> BrandDTOToBrandViewModel(this List<BrandDto> brands)
        {
            return brands.Select(b => b.BrandDTOToBrandViewModel()).ToList();
        }
    }
}
