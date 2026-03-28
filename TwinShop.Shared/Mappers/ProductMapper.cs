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
        public static ProductDto ToProductDTO(this ProductViewModel productView)
        {
            return new ProductDto
            {
                ProductName = productView.ProductName,
                BrandName = productView.BrandName,
                BrandId = productView.BrandId,
                CategoryName = productView.CategoryName,
                Description = productView.Description,
                MainImage= productView.MainImage,
                NumberInStorage = productView.NumberInStorage,
                InitialPrice = productView.InitialPrice, 
                SecondryPrice = productView.SecondryPrice,
                IsDeleted = productView.IsDeleted,
            };
        }
        public static ProductViewModel ToProductViewModel(this ProductDto product)
        {
            return new ProductViewModel
            {
                ProductName = product.ProductName,
                BrandName = product.BrandName,
                BrandId = product.BrandId,
                CategoryName = product.CategoryName,
                Description = product.Description,
                MainImage = product.MainImage,
                NumberInStorage = product.NumberInStorage,
                InitialPrice = product.InitialPrice,
                SecondryPrice = product.SecondryPrice,
                IsDeleted = product.IsDeleted,
            };
        }
    }
}

