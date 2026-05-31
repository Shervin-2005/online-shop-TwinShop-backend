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
                IsDeleted = brandView.IsDeleted,
                CategoryIds = brandView.CategoryIds!,
            };
        }
        public static BrandViewModel BrandDTOToBrandViewModel(this BrandDto brand)
        {
            return new BrandViewModel
            {
                BrandId= brand.BrandId,
                BrandName = brand.BrandName,
                IsDeleted = brand.IsDeleted,
                CategoryIds = brand.CategoryIds,
            };
        }
        public static List<BrandViewModel> BrandDTOToBrandViewModel(this List<BrandDto> brands)
        {
            return brands.Select(b => b.BrandDTOToBrandViewModel()).ToList();
        }
    }
}
