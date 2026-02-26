using Twin_Shop__Web_API.DTOs.Brand;
using Twin_Shop__Web_API.Entities;


namespace Twin_Shop__Web_API.Services.Interfaces
{
    public interface IBrandService
    {
        Task<List<BrandDto>> GetAllBrandsAsync();
        Task< BrandDto?> GetBrandByIdAsync(int id);
        Task<List<BrandDto?>> GetBrandByNameAsync(string name);
        Task<List<BrandDto?>> GetBrandsByCategoryNameAsync(string categoryName);
        Task<BrandDto> CreateBrandAsync(CreateBrandDto dto);
        Task<bool> DeleteBrandAsync(int id);
        Task<bool> UpdateBrandAsync(UpdateBrandDto dto);

    }
}