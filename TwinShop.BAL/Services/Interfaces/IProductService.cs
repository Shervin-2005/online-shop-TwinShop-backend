using Twin_Shop__Web_API.DTOs.Category;
using Twin_Shop__Web_API.DTOs.Product;
using Twin_Shop__Web_API.Entities;


namespace Twin_Shop__Web_API.Services.Interfaces
{
    public interface IProductService
    {
        Task<List<ProductDto>> GetAllProductsAsync();
        Task<ProductDto?> GetProductByIdAsync(int id);
        Task<List<ProductDto?>> GetProductsByNameAsync(string name);
        public Task<List<ProductDto>> GetProductsByBrandNameAsync(string brandName);
        public Task<List<ProductDto>> GetProductsByCategoryNameAsync(string categoryName);
        Task<ProductDto> CreateProductAsync(CreateProductDto dto);
        Task<bool> DeleteProductAsync(int id);
        Task<bool> UpdateProductAsync(UpdateProductDto dto);

    }
}
