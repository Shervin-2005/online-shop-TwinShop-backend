using Twin_Shop__Web_API.DTOs.Product;
using Twin_Shop__Web_API.Entities;
using AutoMapper;

namespace TwinShop.BLL.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>();      
            CreateMap<CreateProductDto, Product>(); 
        }
    }
}
