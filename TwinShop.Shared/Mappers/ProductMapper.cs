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
                BrandId = productView.BrandId,
                CategoryId = productView.CategoryId,
                Description = productView.Description,
                NumberInStorage = productView.NumberInStorage,
                InitialPrice = productView.InitialPrice, 
                SecondaryPrice = productView.SecondaryPrice,
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
                BrandId= product.BrandId!,
                CategoryId = product.CategoryId!,
                Description = product.Description!,
                NumberInStorage = product.NumberInStorage,
                InitialPrice = product.InitialPrice,
                SecondaryPrice = product.SecondaryPrice,
                IsDeleted = product.IsDeleted,
            };
        }
    }
}

