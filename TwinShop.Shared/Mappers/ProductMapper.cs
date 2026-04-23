using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twin_Shop__Web_API.DTOs.Product;
using TwinShop.Shared.ViewModels;

namespace TwinShop.Shared.Mappers
{
    public static class ProductMapper
    {
        public static ProductDto ProductViewModelToProductDTO(this ProductCardViewModel productView)
        {
            return new ProductDto
            {
                ProductName = productView.ProductName,
                ProductId = productView.ProductId,
                BrandName = productView.BrandName,
                BrandId = productView.BrandId,
                CategoryId = productView.CategoryId,
                CategoryName = productView.CategoryName,
                Description = productView.Description,
                MainImageUrl= productView.MainImageUrl,
                NumberInStorage = productView.NumberInStorage,
                InitialPrice = productView.InitialPrice, 
                SecondryPrice = productView.SecondryPrice,
                IsDeleted = productView.IsDeleted,
            };
        }
        public static List<ProductCardViewModel> ProductDTOToProductCardViewModel(this List<ProductDto> products)
        {
            return products.Select(p => p.ProductDTOToProductCardViewModel()).ToList();
        }
        public static ProductCardViewModel ProductDTOToProductCardViewModel(this ProductDto product)
        {
            return new ProductCardViewModel
            {
                ProductName = product.ProductName!,
                ProductId = product.ProductId!,
                BrandName = product.BrandName!,
                CategoryName = product.CategoryName!,
                Description = product.Description!,
                MainImageUrl = product.MainImageUrl,
                NumberInStorage = product.NumberInStorage,
                InitialPrice = product.InitialPrice,
                SecondryPrice = product.SecondryPrice,
                IsDeleted = product.IsDeleted,
            };
        }
    }
}

